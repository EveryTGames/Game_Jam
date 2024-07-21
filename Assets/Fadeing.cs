using UnityEngine;
using UnityEngine.SceneManagement;

public class Fadeing : MonoBehaviour
{
    public static Fadeing fading;
    string nextSceneName;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        if (fading == null)
        {
            fading = this;
        }
        else
        {
            Debug.Log("multyple fading in the scene");
        }
        animator = GetComponent<Animator>();
        fadeIn();

    }
    public void fadeIn()
    {
        animator.SetBool("in", true);
    }
    public void fadeOut(string _nextSceneName)
    {
        animator.SetBool("in", false);
        nextSceneName = _nextSceneName;
    }
    public void load()
    {
        SceneManager.LoadScene(nextSceneName);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
