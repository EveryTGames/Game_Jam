using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttons : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    public void Continue()
    {
        
        split.activePlayer.activePlayerObject.GetComponent<split>().pause();
    }
    public void ReloadLastCheckPoint()
    {

    }
    public void MainMenu()
    {


    }

}
