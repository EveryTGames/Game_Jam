using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuLogic : MonoBehaviour
{
    public float waitTime = 4f;
    public Button continueB,newSaveB,exitB;
    public Animator continueAnim,newSaveAnim,exitAnim;
    void Start()
    {
        continueAnim.enabled = false;
        newSaveAnim.enabled = false;
        exitAnim.enabled = false;
        continueB.onClick.AddListener(continueCall);
        newSaveB.onClick.AddListener(newSaveCall);
        exitB.onClick.AddListener(exitCall);
    }
    void continueLogic()
    {


    }
    void newSaveLogic()
    {


    }
    void exitLogic()
    {
 
    }
    void startAnim(string type)
    {
        if (type == "continue")
        {
            continueAnim.enabled = true;
        }
        else if (type == "save")
        {
            newSaveAnim.enabled= true;
        }
        else if (type == "exit")
        {
            exitAnim.enabled= true;
        }
    }

    IEnumerator waitFor(float time,string type)
    {
        yield return new WaitForSeconds(waitTime);
        if(type == "continue")
        {
            continueLogic();
        }
        else if(type == "save")
        {
            newSaveLogic();
        }
        else if(type == "exit")
        {
            exitLogic();
        }
        

    }
    void continueCall()
    {
        startAnim("continue");
        waitFor(waitTime,"continue");
        Debug.Log("clicked continue ");

    }
    void newSaveCall()
    {
        startAnim("save");
        waitFor(waitTime,"save");
        Debug.Log("clicked new save ");

    }
    void exitCall()
    {
        startAnim("exit");
        waitFor(waitTime,"exit");
        Debug.Log("clicked exit");

    }
}
