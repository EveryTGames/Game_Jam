using UnityEngine;

public class holdingMovingGround : MonoBehaviour
{
    public float range;
    Vector3 finalPosotion;
    Vector3 startPosition;
    public bool horizontal;
    public float speed;


    public triggers[] triggers;

    // Start is called before the first frame update
    void Start()
    {

        if (horizontal)
        {
            finalPosotion = new Vector3 { x = range } + transform.position;

        }
        else
        {
            finalPosotion = new Vector3 { y = range } + transform.position;


        }
        startPosition = transform.position;
    }
    bool maybe, on;
    bool theTargetIsFinal = true;
    bool stopMoving;
    // Update is called once per frame
    void Update()
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



        if (Mathf.Approximately(Vector3.Distance(transform.position, finalPosotion), 0))
        {
            transform.position = finalPosotion;
            theTargetIsFinal = false;
        }
        if (Mathf.Approximately(Vector3.Distance(transform.position, startPosition), 0))
        {
            transform.position = startPosition;
            theTargetIsFinal = false;

        }
    }

    private void FixedUpdate()
    {
        if (!on)
        {
            theTargetIsFinal = false;
        }
        if (stopMoving)
        {

            if (theTargetIsFinal)
            {
                transform.Translate(finalPosotion.normalized * speed);
            }
            else
            {
                transform.Translate(startPosition.normalized * speed);

            }
        }


    }

    public GameObject lr;

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
