using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class lightchanger: MonoBehaviour
{
    Transform parent;
    public float outerRaduis = 0.78f;
    public float startScale = 6;
    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent.parent;
        GetComponent<Light2D>().pointLightOuterRadius = (outerRaduis * parent.localScale.x) / startScale;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
