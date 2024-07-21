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
    public List<Color> colors;
    // Update is called once per frame
    void Update()
    {
        thisPlayerColor = split1.thisPlayerColor;
        colors = staticSlimes.colorList();

    }
    public void killthis()
    {
        split.tabbing();
        Destroy(gameObject);
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("traps"))
    //    {
    //        Debug.Log("im here");
    //        killthis();
    //    }
    //}
}
