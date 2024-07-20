using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingGrioundColor : MonoBehaviour
{
    Animator animator;
    movingGround mg;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        mg = transform.parent.GetComponent<movingGround>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("on", mg.on);
        
    }
}
