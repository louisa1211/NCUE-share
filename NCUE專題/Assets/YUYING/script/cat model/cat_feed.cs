using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cat_feed : MonoBehaviour
{
    public Animator animator;
    bool eat;
    AnimatorStateInfo animatorInfo;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        eat = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(eat);
        animatorInfo = animator.GetCurrentAnimatorStateInfo(0);
    }

    public void ButtonPressed()
    {
        animatorInfo = animator.GetCurrentAnimatorStateInfo(0);

        animator.SetBool("eat", true);
        eat = true;

        if (animatorInfo.IsName("rig|eat"))
        {
            if (animatorInfo.normalizedTime > 0.5f)
            {
                eat = false;
                animator.SetBool("eat", false);
                //animator.SetBool("isSitting", false);
            }
        }

    }
}
