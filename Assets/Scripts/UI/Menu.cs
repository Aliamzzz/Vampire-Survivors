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
    public bool playerInstantiated = false;
    public bool intoTheGame = false;
    [SerializeField] public GameObject fighter;
    [SerializeField] public GameObject assassin;
    public GameObject pausePanel; /// <summary>
                                  /// ///////////
                                  /// </summary>
    [SerializeField] private GameObject barHealth;

    [SerializeField] private GameObject selectionHeroPanel;
    [SerializeField] private GameObject descriptionPanel;
    private bool isFighter = true;

    public GameObject PowerUpPanel; /// <summary>
                                    /// 
                                    /// </summary>
    [SerializeField] private HealthBar hb;
    [SerializeField] private GameOver go;
    [SerializeField] private WorldScroling ws;

    [SerializeField] private GameObject userPanel;
    [SerializeField] private GameObject signUpPanel;
    [SerializeField] private GameObject loginPanel;

    [SerializeField] private TextMeshProUGUI coinText;
    public static int coinNum = 0;
    public int inGameCoinNum = 0;

    public GameObject levelUpPanel;
    public int maxXP = 5;
    public int XP;
    [SerializeField] public TextMeshProUGUI levelText;
    private int level = 1;

    [SerializeField] private SignUp _signUp;
    [SerializeField] private Login _login;
    [SerializeField] public GameObject loggedIn;

    public int bestScore = 0;
    public bool gameOver = false;

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
            playerInstantiated = true;
            intoTheGame = true;
        }
        else
        {
            Instantiate(assassin, Vector3.zero, quaternion.identity);
            playerInstantiated = true;
            intoTheGame = true;
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
        coinNum = inGameCoinNum;
        SceneManager.LoadScene(0);
        AudioListener.pause = false;
        Time.timeScale = 1;
    }

    public void quitGame()
    {
        gameOver = true;
        StartCoroutine(delay());
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
        if (SignUp.isSignUp || Login.isLogin)
        {
            loggedIn.SetActive(true);
            StartCoroutine(delay());
        }
        else
        {
            if (!PowerUpPanel.activeSelf)
            {
                userPanel.SetActive(!userPanel.activeSelf);
            }
        }
    }

    private IEnumerator delay()
    {
        yield return new WaitForSeconds(1f);
        loggedIn.SetActive(false);
    }

    public void login()
    {
        userPanel.SetActive(false);
        loginPanel.SetActive(true);
    }

    public void signUp()
    {
        userPanel.SetActive(false);
        signUpPanel.SetActive(true);
    }

    // private void Start()
    // {
    //     if (PlayerPrefs.HasKey("coin"))
    //     {
    //         coinNum = PlayerPrefs.GetInt("coin");
    //         bestScore = PlayerPrefs.GetInt("best");
    //     }
    // }

    public void Update()
    {
        if (SceneManager.GetActiveScene().name.Equals("Scene 1"))
        {
            coinText.text = "Coins : " + inGameCoinNum;
        }

        if (XP > bestScore)
        {
            bestScore = XP;
        }

        if (XP > maxXP)
        {
            inGameLevelUp();
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            pauseGame();
        }
        //
        // PlayerPrefs.SetInt("coin", coinNum);
        // PlayerPrefs.SetInt("best", bestScore);
        // PlayerPrefs.Save();
    }


    public void addCoin()
    {
        inGameCoinNum++;
    }

    public void addXP()
    {
        XP++;
    }

    private void inGameLevelUp()
    {
        Time.timeScale = 0;
        maxXP += 5;
        XP = 0;
        levelUpPanel.SetActive(true);
        levelText.text = "Level : " + ++level;
    }
    
}
