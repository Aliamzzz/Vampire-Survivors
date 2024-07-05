using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Player player;
    private int healthOfFighter;
    [SerializeField] private GameObject gameOver;

    public void initialing()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    private void FixedUpdate()
    {
        healthOfFighter = (int)player.HP;
        if (player.HP <= 0)
        {
            StartCoroutine(GameOverWithDelay());
        }
    }

    IEnumerator GameOverWithDelay()
    {
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0;
        gameOver.SetActive(true);
    }

    public void backMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

    public void restart()
    {
        SceneManager.LoadScene("Scene 1");
        // gameOver.SetActive(false);
    }
    
}
