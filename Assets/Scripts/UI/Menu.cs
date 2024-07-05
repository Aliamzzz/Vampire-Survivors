using System;
using System.Collections;
using System.Collections.Generic;
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
}
