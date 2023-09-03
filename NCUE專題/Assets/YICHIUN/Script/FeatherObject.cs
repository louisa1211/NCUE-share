using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FeatherObject : MonoBehaviour
{
    
    public Text feathercounter;
    private int counter = 0;
    public GameObject getfeatherPanel;

    void Start()
    {
        getfeatherPanel.SetActive(false);
        StartCoroutine(ShowPanelForSeconds(3f));
    }

    private void UpdateCounter()
    {
        counter++;
        feathercounter.text = counter.ToString();

        if(counter == 10)
        {
            SceneManager.LoadScene("B_win");
        }
    }

    private void Update()
    {
        getfeatherPanel.SetActive(false);

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // 假設只處理第一個觸控點

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject == gameObject)
                    {
                        getfeatherPanel.SetActive(true);
                        Destroy(gameObject);
                        UpdateCounter();
                    }
                }
            }
        }
    }

    private IEnumerator ShowPanelForSeconds(float seconds)
    {
        getfeatherPanel.SetActive(true);
        yield return new WaitForSeconds(seconds);
        getfeatherPanel.SetActive(false);
    }


}
