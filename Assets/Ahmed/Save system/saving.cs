using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class saving : ScriptableObject
{
    public string componentTypeName; // Name of the component to get (e.g., "MyComponent")

    //public void GetComponentByType()
    //{

    //    // Get the type of the component based on the name
    //    Type componentType = Type.GetType(componentTypeName);

    //    // Check if the type exists and is a component
    //    if (componentType != null && componentType.IsSubclassOf(typeof(Component)))
    //    {
    //        // Get the component using reflection
    //        Component component = GetComponent(componentType);

    //    }
    //}



    public static void InspectComponent(Component component)
    {

        Type componentType = component.GetType();

        FieldInfo[] fields = componentType.GetFields(BindingFlags.Public | BindingFlags.Instance);
        Debug.Log(componentType.GetMember("isTrigger")[0]);

        Debug.Log("im ghere");
        foreach (FieldInfo field in fields)
        {
            Debug.Log($"Property Name: {field.Name}, Value: {field.GetValue(component)}");
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="gameobject"> the source of the save</param>
    /// <param name="empty"> the target wich will be opied to</param>
    /// 

    //public static float saveTime = 0;
    static int numberOfChilds;
    static List<int> childs = new List<int>();

    public static float globalAllTime = 0;
    public static void realSave(Transform otherSlimes, Transform playersParent,Transform triggersParent)
    {

        // GameObject[] deads = GameObject.FindGameObjectsWithTag("dead");
        pp obj = new pp();
        for (int i = 0; i < playersParent.childCount; i++)
        {

            obj.position.Add(playersParent.GetChild(i).GetChild(playersParent.GetChild(i).transform.childCount - 1).position);
            obj.scale.Add(playersParent.GetChild(i).localScale.x);
            obj.color.Add(playersParent.GetChild(i).GetComponent<split2>().thisPlayerColor);
            try
            {

                if (playersParent.GetChild(i).GetComponent<split>().isTheActive)
                {
                    obj.activeIndex = i;
                }
            }
            catch (Exception e)
            {
                Debug.LogWarning(e);
            }
        }
        //the above is for the objects in players 

        //the below is for the objects in otherSlimes

        for (int i = 0; i < otherSlimes.childCount; i++)
        {
            
                Vector3 position = (otherSlimes.GetChild(i).GetChild(otherSlimes.GetChild(i).transform.childCount - 1).position);
            

                ActivePlayer.colors color = (otherSlimes.GetChild(i).GetComponent<split2>().thisPlayerColor);

                obj.otherSlimess.Add(new otherSlimes(color, position));
            
            

        }


        //the below is for the objects in treggers

        List<bool> triggers = triggersParent.GetComponentsInChildren<trigger>().Select((t) => t.on).ToList();
      
        obj.triggers = triggers;


        //Debug.Log("saved this in the file" + obj.newSave + "and this the real value" + Controler.newSave);
        string json = JsonUtility.ToJson(obj);



        File.WriteAllText(Path.Combine(Application.dataPath, "Resources/" + "saves.txt"), json);


    }

    public GameObject prefab;
    public static void realLoad(Transform otherSlimsParent, GameObject slimePrefab, Transform playersParent, Transform triggersParent)
    {
        pp obj = new pp();
        obj = JsonUtility.FromJson<pp>(File.ReadAllText(Path.Combine(Application.dataPath, "Resources/" + "saves.txt")));
        for (int i = 0; i < obj.position.Count; i++)
        {
            Transform playerSlime = Instantiate(slimePrefab, playersParent).transform;
            playerSlime.position = obj.position[i] + new Vector3 { y = 0.8f };
            playerSlime.localScale = Vector3.one * obj.scale[i];
            playerSlime.GetComponent<split>().thisPlayerColor = obj.color[i];
            if (i == obj.activeIndex)
            {
                playerSlime.GetComponent<split>().isTheActive = true;
            }

        }
        //this for loading the players

        //below for loading the otherSlimes
        foreach (otherSlimes other in obj.otherSlimess)
        {
            Transform xx = Instantiate(slimePrefab, otherSlimsParent).transform;
            xx.position = other.Item2 + new Vector3 { y = 0.8f };
            xx.GetComponent<split>().thisPlayerColor = other.Item1;

        }

        //Debug.Log(obj.childNumber);

        //thsi is for triggers
        for (int i  = 0; i  < obj.triggers.Count; i++)
        {
            triggersParent.GetChild(i).GetComponent<trigger>().on = obj.triggers[i];
        }
    }


    public static double allTimee;
    //public static void save(GameObject gameobject, GameObject empty)
    //        {
    //            GameObject nw = Instantiate(empty);
    //            Component[] components = gameobject.GetComponents(typeof(Component));
    //            foreach (Component component in components)
    //            {
    //                Debug.Log(component.ToString());
    //                if (nw.GetComponent(component.GetType()) == null)
    //                {
    //                    Component newComponent = nw.AddComponent(component.GetType());
    //                    dynamic x = gameobject.GetComponent(component.GetType());
    //            InspectComponent(x);
    //                   // Debug.Log(x.isTrigger);
    //                    //this is working u can get the properities by its names from the original component then save it, then load it again and do the reverse to aplply the properities and u can use (dynamic properity fitcher ) o get all the properities
    //                }
    //                else
    //                {

    //                    Debug.Log("f;u");
    //                }

    //            }

    //        }
}
[Serializable]
class pp
{
    public List<Vector3> position = new List<Vector3>();
    public List<float> scale = new List<float>();
    public List<ActivePlayer.colors> color = new List<ActivePlayer.colors>();
    public int activeIndex;
    // public int childNumber;
    // public int deathNumber;
    //public bool newSave;

    //public List<int> child;

    public List<otherSlimes> otherSlimess = new List<otherSlimes>();



    // public int numberOfCorpses;
    // public List<corpse> corpsPositions = new List<corpse>();


    public List<bool> triggers = new List<bool>();

    // public bool hardCore;
    // public double allTime;


    // public bool enableSaving;

}

[Serializable]
struct otherSlimes
{
    public ActivePlayer.colors Item1;
    public Vector3 Item2;
    public otherSlimes(ActivePlayer.colors item1, Vector3 item2)
    {
        this.Item1 = item1;
        this.Item2 = item2;
    }
}
