using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScreen : MonoBehaviour
{
    public float waitTime = 4f;
    public Button continueB, reloadCheckPointB, mainMenuB;
    public Animator continueAnim, reloadCheckPointAnim, mainMenuAnim;
    void Start()
    {
        continueAnim.enabled = false;
        reloadCheckPointAnim.enabled = false;
        mainMenuAnim.enabled = false;
        continueB.onClick.AddListener(continueCall);
        reloadCheckPointB.onClick.AddListener(newSaveCall);
        mainMenuB.onClick.AddListener(exitCall);
    }
    void continueLogic()
    {


    }
    void reloadCheckPointLogic()
    {


    }
    void mainMenuLogic()
    {

    }
    void startAnim(string type)
    {
        if (type == "continue")
        {
            continueAnim.enabled = true;
        }
        else if (type == "reload")
        {
            reloadCheckPointAnim.enabled = true;
        }
        else if (type == "mainMenu")
        {
            mainMenuAnim.enabled = true;
        }
    }

    IEnumerator waitFor(float time, string type)
    {
        yield return new WaitForSeconds(waitTime);
        if (type == "continue")
        {
            continueLogic();
        }
        else if (type == "reload")
        {
            reloadCheckPointLogic();
        }
        else if (type == "mainMenu")
        {
            mainMenuLogic();
        }


    }
    void continueCall()
    {
        startAnim("continue");
        waitFor(waitTime, "continue");
        Debug.Log("clicked continue ");

    }
    void newSaveCall()
    {
        startAnim("reload");
        waitFor(waitTime, "reload");
        Debug.Log("clicked reload");

    }
    void exitCall()
    {
        startAnim("mainMenu");
        waitFor(waitTime, "mainMenu");
        Debug.Log("clicked mainMenu");

    }
}
