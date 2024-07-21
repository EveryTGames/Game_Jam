using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menubuttons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void continueLogic()
    {

        Debug.Log("asd");
        Fadeing.fading.fadeOut(1);
    }
   public void newSaveLogic()
    {

        string originalSave = File.ReadAllText(Path.Combine(Application.dataPath, "Resources/" + "orignal_saves.txt"));
        File.WriteAllText(Path.Combine(Application.dataPath, "Resources/" + "saves.txt"), originalSave);
        Fadeing.fading.fadeOut(1);

    }
   public void exitLogic()
    {
        Application.Quit();

    }
}
