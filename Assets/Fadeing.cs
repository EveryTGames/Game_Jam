using UnityEngine;
using UnityEngine.SceneManagement;

public class Fadeing : MonoBehaviour
{
    public static Fadeing fading;
    int nextSceneName;
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
    public void fadeOut(int _nextSceneIndex)
    {
        animator.SetBool("in", false);
        nextSceneName = _nextSceneIndex;
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
