using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    [SerializeField] private TMP_InputField userName;
    [SerializeField] private TMP_InputField password;
    [SerializeField] private GameObject errorPanel;
    [SerializeField] private GameObject loginPanel;
    [SerializeField] private GameObject done;

    public static bool isLogin = false;

    public string userNameString;
    private string passwordString;
    
    
    private IEnumerator delay()
    {
        done.SetActive(true);
        yield return new WaitForSeconds(1f);
        done.SetActive(false);
        exit();
    }


    
    public void confirm()
    {
        userNameString = userName.text;
        passwordString = password.text;

        if (checkUsernameExist(userNameString))
        {
            isLogin = true;
            StartCoroutine(delay());
        }
        else
        {
            errorPanel.SetActive(true);
        }
    }

    public bool checkUsernameExist(string username)
    {
        string filePath = Path.Combine(Application.persistentDataPath, "userInf.txt");
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] userData = line.Split(',');
                if (userData[0] == userNameString && userData[1] == passwordString)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public void exitError()
    {
        errorPanel.SetActive(false);
    }

    public void exit()
    {
        loginPanel.SetActive(false);
    }
    
}