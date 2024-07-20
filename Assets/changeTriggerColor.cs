using UnityEngine;

public class changeTriggerColor : MonoBehaviour
{
    Animator animator;
    trigger trigger;
    SpriteRenderer sr;
    ParticleSystem.MainModule ps;
    ParticleSystem.EmissionModule es;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        trigger = transform.parent.parent.GetComponent<trigger>();
        ps = transform.GetComponentInChildren<ParticleSystem>().main;
        es = transform.GetComponentInChildren<ParticleSystem>().emission;

        sr = transform.parent.GetComponent<SpriteRenderer>();
        if (trigger.needColor)
        {

            sr.color = ActivePlayer.ConvertTheColor(trigger.color);
            

        }
        else
        {

            sr.color = Color.white;
        }

        ps.startColor = sr.color;
    }
    bool firstTime;
    // Update is called once per frame
    void Update()
    {
        animator.SetBool("on", trigger.on);
        if(trigger.on )
        {
            if(firstTime)
            {
                firstTime = false;
                ps.startLifetime = 1.03f;
                ps.startSpeed = 2.04f;
                es.rateOverTime = 4.88f;
            }

        }
        else
        {
            if(!firstTime)
            {
                firstTime = true;
                ps.startLifetime = 1.74f;
                ps.startSpeed = 0.000001f;
                es.rateOverTime = 1.21f;

            }
        }

    }
}
