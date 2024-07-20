using UnityEngine;

public class chamgeColorchanger : MonoBehaviour
{
    changePlayerColor trigger;
    SpriteRenderer sr;
    ParticleSystem.MainModule ps;
    // Start is called before the first frame update
    void Start()
    {
        trigger = transform.parent.parent.GetComponent<changePlayerColor>();
        ps = transform.GetComponentInChildren<ParticleSystem>().main;

        sr = transform.parent.GetComponent<SpriteRenderer>();


        sr.color = ActivePlayer.ConvertTheColor(trigger._changeColorTo);
        ps.startColor = sr.color;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
