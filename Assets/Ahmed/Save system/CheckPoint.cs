using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    
    ParticleSystem _particleSystem;
    // Start is called before the first frame update
    void Start()
    {
        _particleSystem = transform.GetChild(0).GetComponent<ParticleSystem>();
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
            if(Time.time-time >= 30) {

            _particleSystem.Play();
            time = Time.time;
            GameObject.Find("EventSystem").GetComponent<loadManager>().savee();
                GetComponent<AudioSource>().Play();
            Debug.Log("ok it saved?");
            }
           
        }
    }
}
