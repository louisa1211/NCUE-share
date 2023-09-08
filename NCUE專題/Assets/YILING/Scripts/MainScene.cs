using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class MainScene : MonoBehaviour
{
    [SerializeField]
    FirebaseManager firebaseManager;
    [SerializeField]
    InputField inputEmail;
    [SerializeField]
    InputField inputPassword;

    [SerializeField]
    GameObject panelLogin;
    [SerializeField]
    GameObject panelInfo;

    [SerializeField]
    Text textEmail;

    void Start()
    {
        firebaseManager.auth.StateChanged += AuthStateChanged;
    }


    void Update()
    {
        /*if (inputEmail.GetKeyDown(KeyCode.S))
        {
            firebaseManager.SaveData();
        }*/
    }

    public void Register()
    {
        firebaseManager.Register(inputEmail.text, inputPassword.text);
    }

    public void Login()
    {
        firebaseManager.Login(inputEmail.text, inputPassword.text);
    }

    public void Logout()
    {
        firebaseManager.Logout();
    }

    void AuthStateChanged(object sender, System.EventArgs eventArgs)
    {
        if (firebaseManager.user == null)
        {
            textEmail.text = "";
            panelLogin.SetActive(true);
            panelInfo.SetActive(false);
        }
        else
        {
            textEmail.text = firebaseManager.user.Email;
            panelLogin.SetActive(false);
            panelInfo.SetActive(true);
        }
    }

    void OnDestroy()
    {
        firebaseManager.auth.StateChanged -= AuthStateChanged;
    }
}
