using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class staticSlimes : MonoBehaviour
{
    public static staticSlimes s;
    public static List<Color> colorList()
    {
     return   s.transform.GetComponentsInChildren<split2>().Select((t) =>ActivePlayer.ConvertTheColor( t.thisPlayerColor)).ToList();
        
    }
    public static int activeIndex()
    {
        return split.activePlayer.activePlayerObject.transform.GetSiblingIndex();
    }
    // Start is called before the first frame update
    void Start()
    {
        if(s == null)
        {
            s = this;
        }
        else
        {
            Debug.LogWarning("there are more than one players parent");

        }

    }
   
    // Update is called once per frame
    void Update()
    {
       
        
    }
}
