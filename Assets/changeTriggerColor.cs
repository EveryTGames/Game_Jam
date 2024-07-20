using UnityEngine;

public class changeTriggerColor : MonoBehaviour
{
    Animator animator;
    trigger trigger;
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        trigger = transform.parent.parent.GetComponent<trigger>();
        sr = transform.parent.GetComponent<SpriteRenderer>();
        if (trigger.needColor)
        {

            sr.color = ActivePlayer.ConvertTheColor(trigger.color);
        }
        else
        {

            sr.color = Color.white;
        }
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("on", trigger.on);

    }
}
