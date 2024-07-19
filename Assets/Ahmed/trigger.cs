using System.Collections;
using UnityEngine;

public class trigger : MonoBehaviour
{
    public bool mustStay, needColor;
    public ActivePlayer.colors color;
    public bool on;
    public bool oneTimeUse;
    public float timeAfterLeaving;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("core"))
        {
            split2 player = collision.transform.parent.GetComponent<split2>();
            entering(player);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("core"))
        {
            split2 player = collision.transform.parent.GetComponent<split2>();
            Debug.Log("left");

           StartCoroutine(leaving(player));
        }
    }



    public void entering(split2 player)
    {
        if (needColor)
        {
            if (player.thisPlayerColor == color)
            {

                if (oneTimeUse)
                {
                    on = true;

                }
                else
                {
                    on = !on;
                }
            }

        }
        else
        {
            if (oneTimeUse)
            {
                on = true;

            }
            else
            {
                on = !on;
            }

        }
    }


    public IEnumerator leaving(split2 player)
    {
        yield return new WaitForSeconds(timeAfterLeaving);
        if (needColor)
        {
            if (player.thisPlayerColor == color)
            {

                if (mustStay)
                {
                    on = false;



                }

            }


        }
        else
        {
            if (mustStay)
            {
                on = false;



            }
        }
    }
}
