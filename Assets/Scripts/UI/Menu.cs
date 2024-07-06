using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    [SerializeField] public GameObject fighter;
    [SerializeField] public GameObject assassin;

    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject barHealth;

    [SerializeField] private GameObject selectionHeroPanel;
    [SerializeField] private GameObject descriptionPanel;
    private bool isFighter = true;

    [SerializeField] private GameObject PowerUpPanel;
    [SerializeField] private HealthBar hb;
    [SerializeField] private GameOver go;
    [SerializeField] private WorldScroling ws;

    [SerializeField] private GameObject userPanel;
    [SerializeField] private GameObject signInPanel;
    [SerializeField] private GameObject loginPanel;

    [SerializeField] private TextMeshProUGUI coinText;
    public int coinNum = 0;

    [SerializeField] private GameObject levelUpPanel;
    public int maxXP = 25;
    public int XP;
    [SerializeField] public TextMeshProUGUI levelText;
    private int level = 1;


    public void playGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 0;
    }

    public void colseSelection()
    {
        if (isFighter)
        {
            Instantiate(fighter, Vector3.zero, quaternion.identity);
        }
        else
        {
            Instantiate(assassin, Vector3.zero, quaternion.identity);
        }

        selectionHeroPanel.SetActive(false);
        Time.timeScale = 1;
        hb.initialing();
        go.initialing();
        ws.initialing();
    }

    public void FighterSelected()
    {
        isFighter = true;
        descriptionPanel.SetActive(true);
    }

    public void NoFighter()
    {
        isFighter = false;
        descriptionPanel.SetActive(false);
    }

    public void powerUpActive()
    {
        if (true)
        {
            PowerUpPanel.SetActive(true);
        }
    }

    public void goSetting()
    {
        SceneManager.LoadScene(2);
    }

    public void goMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void quitGame()
    {
        Application.Quit();
        // barHealth.SetActive(true);
    }

    public void pauseGame()
    {
        pausePanel.SetActive(true);
        AudioListener.pause = true;
        barHealth.SetActive(false);
        Time.timeScale = 0;
    }

    public void continueButton()
    {
        pausePanel.SetActive(false);
        AudioListener.pause = false;
        barHealth.SetActive(true);
        Time.timeScale = 1;
    }

    public void userlogPanel()
    {
        if (!PowerUpPanel.activeSelf)
        {
            userPanel.SetActive(!userPanel.activeSelf);
        }
    }

    public void login()
    {
        userPanel.SetActive(false);
        loginPanel.SetActive(true);
    }

    public void signIn()
    {
        userPanel.SetActive(false);
        signInPanel.SetActive(true);
    }

    public void Update()
    {
        if (SceneManager.GetActiveScene().name.Equals("Scene 1"))
        {
            coinText.text = "Coins : " + coinNum;
        }

        if (XP > maxXP)
        {
            inGameLevelUp();
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            pauseGame();
        }
    }

    public void addCoin()
    {
        coinNum++;
    }

    public void addXP()
    {
        XP++;
    }

    private void inGameLevelUp()
    {
        Time.timeScale = 0;
        maxXP += 25;
        XP = 0;
        levelUpPanel.SetActive(true);
        levelText.text = "Level : " + ++level;
    }
    
}
