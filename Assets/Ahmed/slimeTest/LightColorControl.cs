using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using static split;
public class LightColorControl : MonoBehaviour
{
    SpriteRenderer sr;
    public bool beForActive; // true to make it follow the active state not the current state
    // Start is called before the first frame update
    void Start()
    {
       sr = transform.parent.parent.GetComponent<SpriteRenderer>();
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
                Color color = ActivePlayer.ConvertTheColor(transform.parent.parent.GetComponent<split>().thisPlayerColor);

                GetComponent<Light2D>().color = color;
                sr.color = new Color(color.r,color.g,color.b,1);
               

            }
        }
    }
}
