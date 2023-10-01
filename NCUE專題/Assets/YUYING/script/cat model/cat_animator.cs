using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cat_animator : MonoBehaviour
{
    private Animator animator;
    public Button btnSitDown;
    public Button btnStandUp;
    public Button btnEat;
    public Button btnLookAround;
    public Button btnWashFace;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();

        if (Variables.catExp <= 1000)
        {
            btnSitDown.interactable = true;
            btnStandUp.interactable = true;
            btnEat.interactable = true;
            btnLookAround.interactable = false;
            btnWashFace.interactable = false;
        }
        if (Variables.catExp > 1000 && Variables.catExp <= 3500)
        {
            btnSitDown.interactable = true;
            btnStandUp.interactable = true;
            btnEat.interactable = true;
            btnLookAround.interactable = true;
            btnWashFace.interactable = false;
        }
        if (Variables.catExp > 3500)
        {
            btnSitDown.interactable = true;
            btnStandUp.interactable = true;
            btnEat.interactable = true;
            btnLookAround.interactable = true;
            btnWashFace.interactable = true;
        }
    }

    public void BtnSitDownPressed()
    {
        animator.ResetTrigger("eat");
        animator.ResetTrigger("lookAround");
        animator.ResetTrigger("washFace");
        animator.SetBool("sitDown", true);
    }
    public void BtnStandUpPressed()
    {
        animator.SetBool("sitDown", false);
        animator.ResetTrigger("eat");
        animator.ResetTrigger("lookAround");
        animator.ResetTrigger("washFace");
    }
    public void BtnEatPressed()
    {
        animator.SetBool("sitDown", false);
        animator.ResetTrigger("lookAround");
        animator.ResetTrigger("washFace");
        animator.SetTrigger("eat");
    }
    public void BtnLookAroundPressed()
    {
        animator.ResetTrigger("eat");
        animator.ResetTrigger("washFace");
        animator.SetTrigger("lookAround");
    }
    public void BtnWashFacePressed()
    {
        animator.SetBool("sitDown", false);
        animator.ResetTrigger("eat");
        animator.ResetTrigger("lookAround");
        animator.SetTrigger("washFace");
    }
}
