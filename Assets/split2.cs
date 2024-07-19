using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class split2 : MonoBehaviour
{
    public ActivePlayer.colors thisPlayerColor;
    split split1;

    // Start is called before the first frame update
    void Start()
    {
        split1 = GetComponent<split>();
    }

    // Update is called once per frame
    void Update()
    {
        thisPlayerColor = split1.thisPlayerColor;
        
    }
}
