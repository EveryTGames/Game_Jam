using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{

    ParticleSystem ps;
    public LayerMask groundLayer;
    public LayerMask wallLayer;
    public float collisionRadius = 0.25f;
    public Vector2 bottomOffSet, rightOffset, leftOffset, upOffset;
  
    private Color debugCollisionColor = Color.red;
    public bool onGround, onWall,onRightWall,onLeftWall;
    void Start()
    {
        ps = GetComponentInChildren<ParticleSystem>();
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    var poistions = new Vector2[] { bottomOffSet, rightOffset, leftOffset };
    //    Gizmos.DrawWireSphere((Vector2)transform.position + bottomOffSet, collisionRadius);
    //    Gizmos.DrawWireSphere((Vector2)transform.position + rightOffset, collisionRadius);
    //    Gizmos.DrawWireSphere((Vector2)transform.position + leftOffset, collisionRadius);
    //    Gizmos.DrawWireSphere((Vector2)transform.position + upOffset, collisionRadius);


    //}
    void Update()
    {
        onGround = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffSet, collisionRadius, groundLayer);
       
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Groundd"))
        {
            ps.Play();
            onGround = true;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Groundd"))
        {
            onGround = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Groundd"))
        {
            ps.Play();
            onGround = false;
        }
    }
}
