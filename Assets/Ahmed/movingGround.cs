using System;
using UnityEngine;

public class movingGround : MonoBehaviour
{
    public float speed;
    public float range;
    [Tooltip("if horizontal is true then the ground will be horizontally if not then it will move vertically")]
    public bool horizontal;
    Vector3 position;
    public float waitingTime;
    float time;
    public bool on = false;

    public bool oneWay;
    float orignalRange;
    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        orignalRange = range;
    }
    bool maybe = false;
    bool canMove = true;
    private void Update()
    {
        maybe = false;
        on = false;
        foreach (triggers triggerEle in triggers)
        {
            if (triggerEle.Must)
            {
                if (!triggerEle.theTrigger.on)
                {
                    on = false;
                    break;

                }
                else
                {
                    on = true;

                }

            }
            else
            {
                if (triggerEle.theTrigger.on)
                {
                    maybe = true;

                    break;

                }

            }
        }

        if (maybe || on || triggers.Length == 0)
        {

            on = true;
        }


        if (Mathf.Abs(Vector3.Magnitude(transform.position - position)) >= range)
        {
            speed = -speed;
            position = transform.position;
            time = Time.time;

            if (oneWay)
            {
                canMove = false;
            }
        }
        else if (!on && needsHold)
        {

            speed = -speed;
            position = transform.position;
            range = tempRange;
            tempRange = 0;
            time = Time.time;

            if (oneWay)
            {
                canMove = false;
            }
        }
    }
    public bool needsHold;
    float tempRange;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (oneWay && !canMove && needsHold && !on)
        {
            if (Mathf.Abs(Vector3.Magnitude(transform.position - position)) >= range)
            {
                speed = -speed;
                position = transform.position;
                time = Time.time;
                range = orignalRange;
                if (oneWay)
                {
                    canMove = true;
                }

            }
            else
            {


                if (horizontal)
                {
                    transform.position += new Vector3 { x = speed * Time.deltaTime };
                }
                else
                {
                    transform.position += new Vector3 { y = speed * Time.deltaTime };

                }
            }


        }
        if (!on)
        {
            return;
        }
        if (Time.time - time >= waitingTime && canMove)
        {

            if (horizontal)
            {
                transform.position += new Vector3 { x = speed * Time.deltaTime };

            }
            else
            {
                transform.position += new Vector3 { y = speed * Time.deltaTime };

            }
            if (needsHold)
            {
                tempRange += speed * Time.deltaTime;
            }
        }


    }
    public GameObject lr;

    public float dampingRatio, frequincy;
    public triggers[] triggers;
    /// <summary>
    /// send the rigidbody of the core
    /// </summary>
    /// <param name="rb"></param>
    public void stick(Rigidbody2D rb)
    {

        //Debug.Log("eneterd");
        ////adding the joint to the player and connecting it 
        //SpringJoint2D xx = gameObject.AddComponent<SpringJoint2D>();

        //xx.connectedBody = rb;
        //xx.autoConfigureConnectedAnchor = false;
        //xx.connectedAnchor = rb.transform.position;
        //xx.autoConfigureDistance = true;

        //xx.dampingRatio = dampingRatio;
        //xx.frequency = frequincy;

    }

    /// <summary>
    /// send the rigidbody of the core
    /// </summary>
    /// <param name="rb"></param>
    public void unstick(Rigidbody2D rb)
    {



        //Debug.Log("left");

        //SpringJoint2D[] springs = GetComponentsInChildren<SpringJoint2D>();
        //foreach (SpringJoint2D spring in springs)
        //{
        //    if (rb == spring.connectedBody)
        //    {
        //        Destroy(spring);
        //        return;
        //    }
        //}
    }
    bool instantiated;
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)//layer of slime
        {
            if (!instantiated)
            {
                foreach (triggers trigerEle in triggers)
                {
                    Color toAdd = (trigerEle.Must) ? Color.red : Color.white;
                    Instantiate(lr, transform.GetChild(1)).GetComponent<lineManager>().setTaget(trigerEle.theTrigger.transform, transform, toAdd);
                }
                instantiated = true;
            }

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)//layer of slime
        {
            if (instantiated)
            {
                for (int i = 0; i < transform.GetChild(1).childCount; i++)
                {
                    Destroy(transform.GetChild(1).GetChild(i).gameObject);
                }
                instantiated = false;
            }

        }
    }

}
[Serializable]
public class triggers
{


    public bool Must;


    public trigger theTrigger;
}
