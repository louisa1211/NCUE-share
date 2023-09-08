using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Firebase;
//using Firebase.Database;
//using Firebase.Extensions;
using System;


public class FirebaseManager : MonoBehaviour
{

    public Firebase.Auth.FirebaseAuth auth;
    public Firebase.Auth.FirebaseUser user;
    
    void Start()
    {
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        auth.StateChanged += AuthStateChanged;
    }

    
    void Update()
    {
        
    }

    public void Register(string email, string password)
    {
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                return;
            }
            if (task.IsFaulted)
            {
                print(task.Exception.InnerException.Message);
                return;
            }
            if (task.IsCompleted)
            {
                if (task.Exception != null)
                {
                    // Handle exception here if needed
                }
                else
                {
                    print("Registered!");
                }
            }
        });
    }

    public async void Login(string email, string password)
    {
        try
        {
            await auth.SignInWithEmailAndPasswordAsync(email, password);
            print("login!");
        }
        catch (Exception ex)
        {
            print(ex.Message);
        }
    }

    public void Logout()
    {
        auth.SignOut();
    }

    /*public void SaveData()
    {
        if(user != null)
        {
            DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
            reference.Child(user.UserId).Child("email").SetValueAsync(user.Email).ContinueWith(task =>
            {
                if (task.IsCompletedSuccessfully)
                {
                    print("saved!");
                }
            });
        }
        else
        {
            print("No user."); 
        }
        
    }

    public void LoadData()
    {

    }*/

    void AuthStateChanged(object sender, System.EventArgs eventArgs)
    {
        if(auth.CurrentUser != user)
        {
            user = auth.CurrentUser;
            if(user != null)
            {
                print($"Login - {user.Email}");
            }
        }
    }

    void OnDestroy()
    {
        auth.StateChanged -= AuthStateChanged; 
    }
}
