using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class cat_game : MonoBehaviour
{
    //canvas
    public Toggle toggleBg;
    public Slider sliderBg;
    public GameObject bg;

    public GameObject btn;
    public GameObject panelEnd;

    //bg
    public GameObject mainCam;
    public GameObject ARCam;
    public GameObject ARCamFloor;

    public Sprite bgNow;
    public Sprite bgPast;
    public Sprite bgFuture;

    //cat anim
    public GameObject cat;
    public Animator animator;

    //cat translate
    public GameObject box;
    private bool coll = false;

    // Start is called before the first frame update
    void Start()
    {
        //canvas
        toggleBg = GameObject.Find("ToggleBg").GetComponent<Toggle>();
        toggleBg.isOn = false;
        btn.SetActive(false);

        //cat anim
        animator = cat.GetComponent<Animator>();
        animator.SetBool("walk", true);

        //bg
        mainCam.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //canvas
        if(toggleBg.isOn == true)
        {
            sliderBg.gameObject.SetActive(true);
            bg.SetActive(true);

            if (sliderBg.value == 0)
            {
                bg.GetComponent<Image>().sprite = bgNow;
            }
            if (sliderBg.value == 1)
            {
                bg.GetComponent<Image>().sprite = bgPast;
            }
            if (sliderBg.value == 2)
            {
                bg.GetComponent<Image>().sprite = bgFuture;
            }

            //bg
            mainCam.SetActive(true);
            ARCam.SetActive(false);
            ARCamFloor.SetActive(false);
        }
        else
        {
            sliderBg.gameObject.SetActive(false);
            bg.SetActive(false);

            //bg
            mainCam.SetActive(false);
            ARCam.SetActive(true);
            ARCamFloor.SetActive(true);
        }

        //cat translate
        if (coll == false)
        {
            var direction = box.transform.position - cat.transform.position;
            cat.transform.Translate(direction.normalized * Time.deltaTime * 5.5f, Space.World);

            var angle = Vector3.Angle(cat.transform.forward, direction);

            var cross = Vector3.Cross(cat.transform.forward, direction);

            var turn = cross.y >= 0 ? 1f : -1f;
            cat.transform.Rotate(cat.transform.up, angle * Time.deltaTime * 5f * turn, Space.World);
        }       
    }

    void OnCollisionEnter(Collision collision)
    {
        animator.SetBool("walk", false);
        coll = true;
        btn.SetActive(true);
    }

    public void ClickOpen()
    {
        panelEnd.SetActive(true);
    }

    public void ClickBack()
    {
        SceneManager.LoadScene("cat_model");
    }
}
