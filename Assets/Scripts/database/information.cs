using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;
using Unity.Mathematics;

public class Information : MonoBehaviour
{
    [SerializeField] private Menu _menu;
    
    [SerializeField] private TextMeshProUGUI coin;
    private static int coinNumber = 45;

    [SerializeField] private TextMeshProUGUI bestScore;
    private int BestScoreNumber = 0;
    
    // [SerializeField] private powerUp _powerUp;
    private int speedLevel = 1;
    private int healthLevel = 1;
    
    [SerializeField] private SignUp _signUp;
    [SerializeField] private Login _login;

    
    private bool isSaved = true;
    private bool isLoaded = true;

    private void Start()
    {
        if (PlayerPrefs.HasKey("coin"))
        {
            if (Login.isLogin)
            {
                coinNumber = PlayerPrefs.GetInt("coin");
                BestScoreNumber = PlayerPrefs.GetInt("best");
            }
            coinNumber += Menu.coinNum;
        }
    }

    private void Update()
    {
        if (Login.isLogin && isLoaded)
        {
            isLoaded = false;
            LoadInfo();
            powerUp.healthLevelValue = healthLevel;
            powerUp.speedLevelValue = speedLevel;
        }
        if ((Login.isLogin || SignUp.isSignUp) && isSaved && _menu.gameOver)
        {
            SaveInfo();
            isSaved = false;
        }

        // PlayerPrefs.SetInt("coin", coinNumber);
        // PlayerPrefs.SetInt("best", BestScoreNumber);
        // PlayerPrefs.Save();
        
        bestScore.text = "Best Score : " + BestScoreNumber;
        coin.text = "Coins : " + coinNumber;

    }

    private void LoadInfo()
    {
        string filePath = Path.Combine(Application.persistentDataPath, "Info.txt");
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] info = line.Split(',');
                if (info[0] == _login.userNameString || info[0] == _signUp.userNameString)
                {
                    BestScoreNumber = int.Parse(info[1]);
                    coinNumber = int.Parse(info[2]);
                    healthLevel = int.Parse(info[3]);
                    speedLevel = int.Parse(info[4]);
                    break;
                }
                BestScoreNumber = BestScoreNumber > _menu.bestScore ? BestScoreNumber : _menu.bestScore;
            }
        }
    }

    private void SaveInfo()
    {
        string filePath = Path.Combine(Application.persistentDataPath, "Info.txt");
        string userName = Login.isLogin ? _login.userNameString : _signUp.userNameString;
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            for (int i = 0; i < lines.Length; i++)
            {
                string[] userData = lines[i].Split(',');
                if (userData[0] == userName)
                {
                    lines[i] = userName + "," + BestScoreNumber + "," + coinNumber + "," + healthLevel + "," + speedLevel;
                    File.WriteAllLines(filePath, lines);
                    return;
                }
            }
        }

        string line = userName + "," + BestScoreNumber + "," + coinNumber + "," + healthLevel + "," + speedLevel;
        using (StreamWriter writer = File.AppendText(filePath))
        {
            writer.WriteLine(line);
        }
    }

    public static bool coinCounter(int n)
    {
        if ((coinNumber - n) >= 0)
        {
            coinNumber -= n;
            return true;
        }
        else return false;
    }
}