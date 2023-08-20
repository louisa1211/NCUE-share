using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelSwitcher : MonoBehaviour
{
    public GameObject[] models; // 所有的模型
    private int currentModelIndex = 0; // 當前顯示的模型索引

    private void Start()
    {
        for (int i = 0; i < models.Length; i++)
        {
            models[i].SetActive(i == currentModelIndex);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 左鍵按下
        {
            SwitchModel();
        }
    }

    private void SwitchModel()
    {
        models[currentModelIndex].SetActive(false);
        currentModelIndex = (currentModelIndex + 1) % models.Length;
        models[currentModelIndex].SetActive(true);
    }
}





