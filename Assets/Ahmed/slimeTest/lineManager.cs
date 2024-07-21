using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class lineManager : MonoBehaviour
{
    LineRenderer lineRenderer;
    Transform target;
    Transform start;
    Vector3 offset;
    Color color;
    public void setTaget(Transform target, Transform start,  [Optional] Color color, [Optional] Vector3 offset)
    {

        this.target = target;
        this.start = start;
        this.offset = offset;
        this.color = color;
    }
    public void ditatch(Transform start)
    {


        this.start = start;

    }
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        if (color != new Color())
        {
            
            for (int i = 0; i < lineRenderer.colorGradient.colorKeys.Length; i++)
            {

                lineRenderer.colorGradient.colorKeys[i].color = color;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {

            lineRenderer.SetPosition(0, start.position);
            lineRenderer.SetPosition(1, target.position + offset);
        }

    }
}
