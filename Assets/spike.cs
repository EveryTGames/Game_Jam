using UnityEngine;
using UnityEngine.SceneManagement;

public class spike : MonoBehaviour
{
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
            Debug.Log("kjshsdghkjsdgjklsg");

            if (collision.transform.parent.gameObject == split.activePlayer.activePlayerObject)
            {

                if (split.tabbing())
                {

                    Destroy(collision.transform.parent.gameObject);
                }
                else
                {
                    Debug.Log("game Over");
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
            else
            {
                Destroy(collision.transform.parent.gameObject);

            }

        }
    }
}
