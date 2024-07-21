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
    Dictionary<Color, Sprite> mp;

    int pt = 0;
    
    void Start()
    {
        images = gameObject.transform.GetComponentsInChildren<Image>();
        mp = new Dictionary<Color, Sprite>
        {
            { ActivePlayer.red, redT },
            { ActivePlayer.blue, blueT },
            { ActivePlayer.green, greenT },
            { ActivePlayer.purble, purpleT },
            { ActivePlayer.cyan, cyanT },
            { ActivePlayer.yellow, yellowT }
        };


    }

    // Update is called once per frame
    void Update()
    {
        List<Color> l = staticSlimes.colorList();
        int i = 0;

        for (; i < l.Count && i < images.Length; i++)
        {
            images[i].enabled = true;
            images[i].sprite = mp[l[i]];

        }
        for (int j = i + 1; j < images.Length; j++)
        {
            images[j].sprite = none;
            images[j].enabled = false;
        }
        Debug.Log(l.Count);


    }
}
