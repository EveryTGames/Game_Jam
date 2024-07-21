using System.Collections;
using UnityEngine;


public class ActivePlayer
{
    public enum colors { red, blue, green, yellow, purble, cyan };
    public GameObject activePlayerObject;
    public colors activePlayerColor = colors.green;
    public static Color red = new Color32(163, 17, 19, 191);
    public static Color blue = new Color32(17, 32, 163, 191);
    public static Color green = new Color32(22, 163, 17, 191);
    public static Color yellow = new Color32(160, 163, 17, 191); // red + green
    public static Color purble = new Color32(163, 17, 146, 191); // red + blue
    public static Color cyan = new Color32(17, 163, 154, 191); // green + blue

    public static Color ConvertTheColor(colors color)
    {
        switch (color)
        {
            case colors.red:
                return red;
            case colors.blue:
                return blue;
            case colors.green:
                return green;
            case colors.yellow:
                return yellow;
            case colors.purble:
                return purble;
            case colors.cyan:
                return cyan;
            default:
                return Color.white;
                break;
        }

    }
    public static colors operator +(ActivePlayer a, colors b)
    {
        colors ac = a.activePlayerColor;
        colors bc = b;

        if (ac != bc)
        {
            if ((ac == colors.red || ac == colors.green) && (bc == colors.red || bc == colors.green))
            {
                return colors.yellow;

            }
            if ((ac == colors.red || ac == colors.blue) && (bc == colors.red || bc == colors.blue))
            {
                return colors.purble;

            }
            if ((ac == colors.green || ac == colors.blue) && (bc == colors.green || bc == colors.blue))
            {
                return colors.cyan;

            }
            else
            {
                return ac; //if secondary with primary
            }
        }
        else
        {
            return ac;
        }

    }
}
public class split : MonoBehaviour
{
    public ActivePlayer.colors thisPlayerColor = ActivePlayer.colors.green;

    public int numberOfSplitestsLeft = 0;
    public static ActivePlayer activePlayer = new ActivePlayer();
    public GameObject slime;

    static Transform playersParent;
    Collider2D c2D;
    public bool isTheActive = false;
    // Start is called before the first frame update
    void Start()
    {
       
        if (activePlayer.activePlayerObject == null && isTheActive)
        {

            activePlayer.activePlayerObject = gameObject;
        }
        if (playersParent == null && isTheActive)
        {
            playersParent = transform.parent;
        }
        c2D = gameObject.GetComponent<Collider2D>();

        numberOfSplitestsLeft = (int)(transform.localScale.x / 4) - 1;
        PauseMenu = GameObject.FindWithTag("pauseMenue");
    }
     GameObject PauseMenu;
    // Update is called once per frame
    void Update()
    {
        // for the pause Menu
        if (Input.GetKeyDown(KeyCode.Escape) && activePlayer.activePlayerObject == gameObject)
        {
            pause();

        }
        if(paused)
        {
            return;
        }
        if (activePlayer.activePlayerObject != gameObject)
        { //no active
            isTheActive = false;
            try
            {

                transform.GetChild(transform.childCount - 1).GetComponent<movement>().enabled = false;
                transform.GetChild(transform.childCount - 1).GetComponent<collision>().enabled = false;
                transform.GetChild(transform.childCount - 1).GetComponent<Grapple>().enabled = false;
            }
            catch { }

            this.enabled = false;
            return;
        }
        else
        {//active
            activePlayer.activePlayerColor = thisPlayerColor;
            isTheActive = true;
        }
        if (activePlayer.activePlayerObject == gameObject)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                thisPlayerColor = ActivePlayer.colors.red;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                thisPlayerColor = ActivePlayer.colors.blue;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                thisPlayerColor = ActivePlayer.colors.green;
            }

        }
        c2D.offset = transform.GetChild(transform.childCount - 1).localPosition;
        if (Input.GetMouseButtonDown(0) && numberOfSplitestsLeft > 0 && activePlayer.activePlayerObject == gameObject)
        {
            StopAllCoroutines();
            StartCoroutine(splitt());
        }//for splitting
        if (Input.GetKeyDown(KeyCode.Tab) && activePlayer.activePlayerObject == gameObject)
        {
            tabbing();
        } //for switching between players


        if (Input.GetMouseButtonDown(1) && activePlayer.activePlayerObject == gameObject && possibleToJoin != null)
        {
            StopAllCoroutines();

            StartCoroutine(join(possibleToJoin));
        }//for rejoining



       
    }
   public bool paused = false;
    public void pause()
    {
        paused = !paused;
        PauseMenu.SetActive(paused);
        if (paused)
        {
            Time.timeScale = 0f;
        }
        else
        {

            Time.timeScale = 1f;
        }
    }

    
    //return true if there were another player
    public static bool tabbing()
    {
        int newIndex = activePlayer.activePlayerObject.transform.GetSiblingIndex() + 1;
        if (newIndex >= playersParent.childCount)
        {
            newIndex = 0;
        }
        if (activePlayer.activePlayerObject.transform.GetSiblingIndex() == newIndex)
        {
            return false;
        }

        activePlayer.activePlayerObject = playersParent.GetChild(newIndex).gameObject;
        Debug.Log(activePlayer.activePlayerObject.name);
        try
        {

            activePlayer.activePlayerObject.transform.GetChild(activePlayer.activePlayerObject.transform.childCount - 1).GetComponent<movement>().enabled = true;
            activePlayer.activePlayerObject.transform.GetChild(activePlayer.activePlayerObject.transform.childCount - 1).GetComponent<collision>().enabled = true;
            activePlayer.activePlayerObject.transform.GetChild(activePlayer.activePlayerObject.transform.childCount - 1).GetComponent<Grapple>().enabled = true;


        }
        catch { }
        activePlayer.activePlayerObject.GetComponent<split>().enabled = true;
        return true;

    }
    Transform possibleToJoin;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider != null)
        {

            if (collider.transform.parent != transform)
            {
                if (collider.CompareTag("core"))
                {

                    possibleToJoin = collider.transform.parent.GetChild(transform.childCount - 1);
                    return;
                }
            }
            //part for the moveing ground
            if (collider.CompareTag("movingGround"))
            {
                collider.GetComponent<movingGround>().stick(transform.GetChild(transform.childCount - 1).GetComponent<Rigidbody2D>());
                return;

            }     //                                                                                                     ^the rigidbody2d component of the core
        }

    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.transform.parent != transform)
        {
            if (possibleToJoin != null)
            {
                if (collider.transform == possibleToJoin)
                {
                    possibleToJoin = null;

                }
                return;

            }

            //part fort hte moving ground
            if (collider.CompareTag("movingGround"))
            {
                collider.GetComponent<movingGround>().unstick(transform.GetChild(transform.childCount - 1).GetComponent<Rigidbody2D>());
                return;

            }     //                                                                                                     ^the rigidbody2d component of the core

        }

    }
    public float dashspeedAfterSplit;
    IEnumerator splitt()
    {
        //numberOfSplitestsLeft--;

        //transform.GetChild(transform.childCount - 1).GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        yield return 0;
        Vector2 velocity = transform.GetChild(transform.childCount - 1).GetComponent<Rigidbody2D>().velocity;
        GameObject newSplitted = Instantiate(slime, playersParent);
        GameObject newSplitted2 = Instantiate(slime, playersParent);
        Debug.Log(transform.GetChild(transform.childCount - 1).position);

        // newSplitted.transform.localPosition = Vector3.zero;
        //newSplitted2.transform.localPosition = Vector3.zero;


        newSplitted.transform.position = transform.GetChild(transform.childCount - 1).position;
        newSplitted2.transform.position = transform.GetChild(transform.childCount - 1).position;
        startTime = Time.time;
        newSplitted.transform.GetChild(transform.childCount - 1).GetComponent<Rigidbody2D>().velocity = velocity * 1.5f;
        newSplitted2.transform.GetChild(transform.childCount - 1).GetComponent<Rigidbody2D>().velocity = velocity;
        newSplitted2.transform.GetChild(transform.childCount - 1).GetComponent<Rigidbody2D>().AddForce(dashspeedAfterSplit * (Vector2)(Camera.main.ScreenToWorldPoint(Input.mousePosition) - newSplitted2.transform.GetChild(transform.childCount - 1).position).normalized, ForceMode2D.Force);



        // StartCoroutine(interpolate(velocity, velocity + dashspeedAfterSplit * (Vector2)(Camera.main.ScreenToWorldPoint(Input.mousePosition) - newSplitted2.transform.GetChild(transform.childCount - 1).position).normalized, newSplitted2.transform.GetChild(transform.childCount - 1).GetComponent<Rigidbody2D>()));
        //Debug.Log(newSplitted.transform.GetChild(transform.childCount - 1).GetComponent<Rigidbody2D>().velocity.y);

        Debug.Log(newSplitted.transform.GetChild(transform.childCount - 1).position);


        // newSplitted.GetComponent<split>().numberOfSplitestsLeft = numberOfSplitestsLeft;
        //newSplitted2.GetComponent<split>().numberOfSplitestsLeft = numberOfSplitestsLeft;
        newSplitted.GetComponent<split>().thisPlayerColor = thisPlayerColor;
        newSplitted2.GetComponent<split>().thisPlayerColor = thisPlayerColor;


        newSplitted.transform.localScale = activePlayer.activePlayerObject.transform.localScale - (Vector3.one * 4);
        //newSplitted2.transform.localScale = activePlayer.activePlayerObject.transform.localScale - (Vector3.one * 4);

        activePlayer.activePlayerObject = newSplitted2;
        activePlayer.activePlayerColor = newSplitted2.GetComponent<split>().thisPlayerColor;


        Destroy(gameObject);



    }


    IEnumerator join(Transform toJoinWith)
    {
        //  numberOfSplitestsLeft++;

        //transform.GetChild(transform.childCount - 1).GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        yield return 0;
        Vector2 velocity = transform.GetChild(transform.childCount - 1).GetComponent<Rigidbody2D>().velocity;
        GameObject newSplitted = Instantiate(slime, playersParent);

        Debug.Log(transform.GetChild(transform.childCount - 1).position);

        // newSplitted.transform.localPosition = Vector3.zero;
        //newSplitted2.transform.localPosition = Vector3.zero;

        Vector3 newPos = (transform.GetChild(transform.childCount - 1).position + toJoinWith.position) / 2;
        newSplitted.transform.position = new Vector3 { x = newPos.x, y = newPos.y + 0.8f };

        startTime = Time.time;
        newSplitted.transform.GetChild(transform.childCount - 1).GetComponent<Rigidbody2D>().velocity = velocity * 0.5f;



        // StartCoroutine(interpolate(velocity, velocity + dashspeedAfterSplit * (Vector2)(Camera.main.ScreenToWorldPoint(Input.mousePosition) - newSplitted2.transform.GetChild(transform.childCount - 1).position).normalized, newSplitted2.transform.GetChild(transform.childCount - 1).GetComponent<Rigidbody2D>()));
        //Debug.Log(newSplitted.transform.GetChild(transform.childCount - 1).GetComponent<Rigidbody2D>().velocity.y);

        Debug.Log(newSplitted.transform.GetChild(transform.childCount - 1).position);


        //  newSplitted.GetComponent<split>().numberOfSplitestsLeft = numberOfSplitestsLeft;
        newSplitted.GetComponent<split>().thisPlayerColor = activePlayer + toJoinWith.parent.GetComponent<split>().thisPlayerColor;
        //                                                       ^ the current  active player                             ^  the color of the slim that the player wants to join with

        newSplitted.transform.localScale = activePlayer.activePlayerObject.transform.localScale + toJoinWith.parent.localScale;

        activePlayer.activePlayerObject = newSplitted;
        activePlayer.activePlayerColor = newSplitted.GetComponent<split>().thisPlayerColor;


        Destroy(toJoinWith.parent.gameObject);
        Destroy(gameObject);
        yield break;
    }

    float startTime;
    public float changeTime = 1;
    IEnumerator interpolate(Vector3 startVelocity, Vector3 endVelocity, Rigidbody2D rb)
    {
        while (Time.time - startTime < changeTime)
        {

            rb.velocity = Vector3.Lerp(startVelocity, endVelocity, (Time.time - startTime) / changeTime);
            yield return null;
        }
    }
}
