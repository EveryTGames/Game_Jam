using UnityEngine;
using UnityEngine.Rendering.Universal;
using static split;
public class LightColorControl : MonoBehaviour
{
    public bool beForActive; // true to make it follow the active state not the current state
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (activePlayer != null)
        {
            if (beForActive)
            {

                        GetComponent<Light2D>().color = ActivePlayer.ConvertTheColor(activePlayer.activePlayerColor);
                

            }

            else
            {

                        GetComponent<Light2D>().color = ActivePlayer.ConvertTheColor(transform.parent.parent.GetComponent<split>().thisPlayerColor);

               

            }
        }
    }
}
