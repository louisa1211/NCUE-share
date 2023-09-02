using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cat_canvasChooseBox : MonoBehaviour
{
    public GameObject box;
    public GameObject box1;
    public GameObject box2;

    public GameObject panelIntro;

    public void ClickConfirm()
    {
        panelIntro.SetActive(false);

        box.GetComponent<cat_box>().enabled = true;
        box1.GetComponent<cat_box>().enabled = true;
        box2.GetComponent<cat_box>().enabled = true;
    }

    public void ClickBack()
    {
        SceneManager.LoadScene("cat_model");
    }
}
