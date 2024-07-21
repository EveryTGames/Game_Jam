using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeplayericeleSystemSize : MonoBehaviour
{

    ParticleSystem.MainModule ops;
    // Start is called before the first frame update
    void Start()
    {
        ops = GetComponent<ParticleSystem>().main;
        //ops.startSize =   transform.parent.parent.localScale.x * 0.21f/4;
        transform.localScale = transform.parent.parent.localScale * 0.25f / 4;
        Debug.Log(transform.localScale) ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
