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

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    private void FixedUpdate()
    {
        healthOfFighter = (int)player.HP;
        if(player.HP <= 0){
            Time.timeScale = 0;
            gameOver.SetActive(true);
        }
    }

    public void backMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

    public void restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Scene 1");
        // gameOver.SetActive(false);
    }
    
}
