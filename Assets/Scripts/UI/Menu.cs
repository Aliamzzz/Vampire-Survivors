using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene(1);
    }

    public void goSetting()
    {
        SceneManager.LoadScene("Scene 1");
    }

    public void goMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void quitGame()
    {
        Application.Quit();
    }
}
