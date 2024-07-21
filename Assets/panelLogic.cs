using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using UnityEngine.UI;
using UnityEngine;

public class panelLogic : MonoBehaviour
{
    // Start is called before the first frame update
    Image []images;
    public Sprite redT,greenT,blueT,purpleT,yellowT,cyanT,none;
    Vector2 orignalS;
    Dictionary<Color, Sprite> mp;

    int pt = 0;
    
    void Start()
    {
        images = gameObject.transform.GetComponentsInChildren<Image>().Where((t,i)=>i>0).ToArray();
       
        mp = new Dictionary<Color, Sprite>
        {
            { ActivePlayer.red, redT },
            { ActivePlayer.blue, blueT },
            { ActivePlayer.green, greenT },
            { ActivePlayer.purble, purpleT },
            { ActivePlayer.cyan, cyanT },
            { ActivePlayer.yellow, yellowT }
        };
        orignalS = images[0].transform.localScale;


    }

    // Update is called once per frame
    void Update()
    {
        List<Color> l = staticSlimes.colorList();
        int idx = staticSlimes.activeIndex();
        int i = 0;

        for (; i < l.Count && i < images.Length; i++)
        {
            images[i].enabled = true;
            images[i].sprite = mp[l[i]];
            images[i].transform.localScale = orignalS;
            if(i == idx)
            {
                images[i].transform.localScale = new Vector2(0.84f,0.84f);
            }

        }
      
        for (int j = i ; j < images.Length; j++)
        {
            images[j].sprite = none;
            images[i].transform.localScale = orignalS;
            images[j].enabled = false;
        }
      


    }
}
