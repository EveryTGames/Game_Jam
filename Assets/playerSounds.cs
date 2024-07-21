using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSounds : MonoBehaviour
{
    public List<AudioClip> sounds;
    public static List<AudioClip> static_sounds;
    //0 walk
    
   static  AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>(); 
    }
    public static void walk()
    {
        
    }
    public static void playonce(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
