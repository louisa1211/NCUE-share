using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class FacebookScript : MonoBehaviour
{
    public TMP_Text FB_userName;
    public Image FB_useerDp;
    public TMP_Text buttonLabel;
    private bool isFirstButtonClick = true;
    private bool isFbInitialized = false;

    private void Awake()
    {
        FB.Init(SetInit, onHideUnity);
    }

    private void SetInit()
    {
        if (FB.IsInitialized && FB.IsLoggedIn)
        {
            Debug.Log("Facebook is Logged in!");
            isFbInitialized = true;
        }
        else if (FB.IsInitialized && !FB.IsLoggedIn)
        {
            Debug.Log("Facebook is Initialized but not Logged in");
            isFbInitialized = true;
        }
        else
        {
            Debug.Log("Facebook initialization failed. Retrying...");
            FB.Init(SetInit, onHideUnity);
        }
    }

    private void onHideUnity(bool isGameShown)
    {
        if (!isGameShown)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void OnButtonClick()
    {
        if (isFirstButtonClick)
        {
            // 第一次按下按鈕，執行Facebook登入
            List<string> permissions = new List<string>();
            permissions.Add("public_profile");
            FB.LogInWithReadPermissions(permissions, AuthCallback);
            isFirstButtonClick = false;
            // 改變按鈕上的文字
            buttonLabel.text = "按此進入遊戲";
        }
        else
        {
            // 第二次按下按鈕，切換場景
            SceneManager.LoadScene("1_Home"); // 將 "YourSceneName" 替換為您想要切換的場景名稱
        }
    }

    private void AuthCallback(ILoginResult result)
    {
        if (result.Error != null)
        {
            Debug.LogError("Facebook login error: " + result.Error);
            // 登入失敗，還原按鈕上的文字為 "登入"
            buttonLabel.text = "登入";
        }
        else if (FB.IsLoggedIn)
        {
            Debug.Log("Facebook is Logging in!");
            DealWithFbMenus(true);
        }
        else
        {
            Debug.LogWarning("Facebook is not Logged in");
            // 登入失敗，還原按鈕上的文字為 "登入"
            buttonLabel.text = "登入";
        }
    }

    void DealWithFbMenus(bool IsLoggedIn)
    {
        if (IsLoggedIn)
        {
            FB.API("/me?fields=first_name", HttpMethod.GET, DisplayUsername);
            FB.API("/me/picture?type=square&height=128&width=128", HttpMethod.GET, DisplayProfilePic);
        }
        else
        {
            // 處理未登入的情況
        }
    }

    void DisplayUsername(IResult result)
    {
        if (result.Error == null)
        {
            string name = "" + result.ResultDictionary["first_name"];
            Debug.Log("" + name);
            FB_userName.text = name;
        }
        else
        {
            Debug.LogError("Error retrieving user name: " + result.Error);
        }
    }

    void DisplayProfilePic(IGraphResult result)
    {
        if (result.Texture != null)
        {
            Debug.Log("Profile Pic");

            // 創建一個新的 Sprite 並將 Texture 設定為它的紋理
            Sprite profilePicSprite = Sprite.Create(result.Texture, new Rect(0, 0, result.Texture.width, result.Texture.height), new Vector2(0.5f, 0.5f));

            // 將 Sprite 設定到 Image 元件上
            FB_useerDp.sprite = profilePicSprite;
        }
        else
        {
            Debug.LogError("Error retrieving profile picture: " + result.Error);
        }
    }
}
