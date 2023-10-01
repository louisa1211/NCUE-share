using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ani : MonoBehaviour
{

    public Animator animator;
    public Button dead;
    public Button roll;
    public Button shakehand;
    public Button sit;


    public void deadAnimation()
    {
        animator.SetBool("dead", true);
        animator.ResetTrigger("roll");
        animator.ResetTrigger("shake");
        animator.ResetTrigger("sit");
    }
    public void rollAnimation()
    {
        animator.SetBool("roll", true);
        animator.ResetTrigger("dead");
        animator.ResetTrigger("shake");
        animator.ResetTrigger("sit");
    }
    public void shakehandAnimation()
    {
       animator.SetBool("shake", true);
       animator.ResetTrigger("roll");
       animator.ResetTrigger("dead");
       animator.ResetTrigger("sit");
    }
    public void sitAnimation()
    {
        animator.SetBool("sit", true);
        animator.ResetTrigger("roll");
        animator.ResetTrigger("shake");
        animator.ResetTrigger("dead");
    }
}
