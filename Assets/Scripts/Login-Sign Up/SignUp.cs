using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;

public class SignUp : MonoBehaviour
{
    [SerializeField] private TMP_InputField userName;
    [SerializeField] private TMP_InputField password;
    [SerializeField] private GameObject errorPanel;
    [SerializeField] private GameObject signUpPanel;
    [SerializeField] private GameObject done;

    public static bool isSignUp = false;

    public string userNameString;
    private string passwordString;

    private IEnumerator delay()
    {
        done.SetActive(true);
        yield return new WaitForSeconds(1f);
        done.SetActive(false);
        signUpPanel.SetActive(false);
    }
    
    public void confirm()
    {
        if (userName.text.Length >= 8 && password.text.Length >= 8)
        {
            userNameString = userName.text;
            passwordString = password.text;

            if (checkUsernameExist(userNameString))
            {
                errorPanel.SetActive(true);
            }
            else
            {
                string filePath = Path.Combine(Application.persistentDataPath, "userInf.txt");
                using (StreamWriter writer = File.AppendText(filePath))
                {
                    writer.WriteLine(userNameString + "," + passwordString);
                }

                isSignUp = true;
                PlayerPrefs.SetInt("isSignUp", 1);
                StartCoroutine(delay());
            }
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
                if (userData[0] == username)
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
        signUpPanel.SetActive(false);
    }
}