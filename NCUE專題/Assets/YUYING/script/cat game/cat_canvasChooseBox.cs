using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cat_canvasChooseBox : MonoBehaviour
{
    public void ClickCancel()
    {
        gameObject.SetActive(false);
    }

    public void ClickDone()
    {
        SceneManager.LoadScene("cat_game");
    }
}
