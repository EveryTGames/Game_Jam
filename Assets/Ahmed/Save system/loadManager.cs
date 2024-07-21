using System;
using System.IO;
using UnityEditor;
using UnityEngine;
[Serializable]
public class loadManager : MonoBehaviour
{
    // public List<GameObject> interacableItems = new List<GameObject>();



    public GameObject slime_Prefab;
    //  public  GameObject colorOrbs;
    public Transform playersParent;
    public Transform otherSlimesParent;
    public Transform triggersParent;
    //public CheckPoint lastCheck;
    
  
    
    private void Start()
    {
           // saveTime = Time.time;
        try
        {
           

            saving.realLoad(otherSlimesParent, slime_Prefab, playersParent,triggersParent);

        }
        catch (Exception e)
        {
            Debug.Log("file error");
          //  Controler.newSave = true;

        }
    }
    public void loade()
    {
       // saving.realLoad(GameObject.Find("color orbs"), colorOrbs_prefab, player);



    }
    public void savee()
    {
      
        saving.realSave(otherSlimesParent, playersParent,triggersParent);

    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            savee();
        }
     
       
    }

    
    

}

[Serializable]
class Player_Data
{
    public GameObject parent;
    public int childNumber;






}


