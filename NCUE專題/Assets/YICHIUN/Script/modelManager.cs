using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modelManager : MonoBehaviour
{
    public GameObject Model1;
    public GameObject Model2;
    public GameObject Model3;
    public GameObject Model4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnModel1Click()
    {
        Model1.SetActive(true);
        Model2.SetActive(false);
        Model3.SetActive(false);
        Model4.SetActive(false);
    }
    public void OnModel2Click()
    {
        Model1.SetActive(false);
        Model2.SetActive(true);
        Model3.SetActive(false);
        Model4.SetActive(false);
    }
        public void OnModel3Click()
    {
        Model1.SetActive(false);
        Model2.SetActive(false);
        Model3.SetActive(true);
        Model4.SetActive(false);
    }
        public void OnModel4Click()
    {
        Model1.SetActive(false);
        Model2.SetActive(false);
        Model3.SetActive(false);
        Model4.SetActive(true);
    } 
}
