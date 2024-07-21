using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        Time.timeScale = 1;
        Fadeing.fading.fadeOut(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(0);


    }

}
