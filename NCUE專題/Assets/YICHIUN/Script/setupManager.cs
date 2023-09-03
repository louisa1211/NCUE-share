using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class setupManager : MonoBehaviour
{
    public GameObject kmCanvas, stepCanvas;
    public GameObject confirmPanel_km, confirmPanel_step;
    public InputField kmText, stepText;
    public Text finalkmText, finalstepText, warnkmText, warnstepText;

    // Start is called before the first frame update
    void Start()
    {
        confirmPanel_km.SetActive(false);
        confirmPanel_step.SetActive(false);
        warnkmText.gameObject.SetActive(false);
        warnstepText.gameObject.SetActive(false);
    }

    public void OnkmButtonClick()
    {
        kmCanvas.SetActive(true);
        stepCanvas.SetActive(false);
    }

    public void OnstepButtonClik()
    {
        kmCanvas.SetActive(false);
        stepCanvas.SetActive(true);
    }

    public void OnkmconfirmButtonClick()
    {
        string inputText;

        inputText = kmText.text;

        if(int.TryParse(inputText, out int inputvalue) && inputvalue > 0)
        {
            confirmPanel_km.SetActive(true);
            finalkmText.text = inputText;   
        }else{
            warnkmText.gameObject.SetActive(true);
        }
    }

    public void OnstepconfirmButtonClick()
    {
        string inputText;

        inputText = stepText.text;

        if(int.TryParse(inputText, out int inputValue) && inputValue > 0)
        {       
            confirmPanel_step.SetActive(true);
            finalstepText.text = inputText;  
        }else{
            warnstepText.gameObject.SetActive(true);
        }       
    }

    public void OnconfirmButtonClick()
    {
        PlayerPrefs.SetString("PreviousScene", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("B_map");
    }

    public void OnregretButtonClick()
    {
        confirmPanel_km.SetActive(false);
        confirmPanel_step.SetActive(false);
        warnkmText.gameObject.SetActive(false);
        warnstepText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
