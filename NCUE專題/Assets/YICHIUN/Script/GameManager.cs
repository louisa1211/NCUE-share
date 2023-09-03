using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject leavePanel;

    void Start()
    {
        leavePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;   
    }

    public void OnleaveButtontClick()
    {       
        leavePanel.SetActive(true);
        PauseGame();
    }

    public void OnconfirmButtonClick()
    {

    }

    public void OncancelButtonClick()
    {
        leavePanel.SetActive(false);
        ResumeGame();
    }

    public void OnMapButtontClick()
    {      
        PlayerPrefs.SetString("PreviousScene", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("B_map");
    }

}


