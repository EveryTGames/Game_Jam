using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    float time;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("core")  )
        {
            if(Time.time-time >= 1) {

            
           
            GameObject.Find("EventSystem").GetComponent<loadManager>().savee();
            Debug.Log("ok it saved?");
            }
           
        }
    }
}
