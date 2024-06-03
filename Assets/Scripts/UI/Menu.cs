using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject barHealth;
    public void playGame()
    {
        SceneManager.LoadScene(1);
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
        barHealth.SetActive(true);
    }

    public void pauseGame()
    {
        pausePanel.SetActive(true);
        barHealth.SetActive(false);
        Time.timeScale = 0;
    }

    public void continueButton()
    {
        pausePanel.SetActive(false);
        barHealth.SetActive(true);
        Time.timeScale = 1;
    }
}
