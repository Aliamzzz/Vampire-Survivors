using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class powerUp : MonoBehaviour
{
    private Menu _menu;
    
    [SerializeField] private GameObject PowerUpPanel;
    [SerializeField] private TextMeshProUGUI speedPriceText;
    public int speedPriceValue = 5;
    [SerializeField] private TextMeshProUGUI healthPriceText;
    public int healthPriceValue = 10;
    [SerializeField] private TextMeshProUGUI speedLevelText;
    public static int speedLevelValue;
    [SerializeField] private TextMeshProUGUI healthLevelText;
    public static int healthLevelValue;

    public void Start()
    {
        if (!Login.isLogin)
        {
            healthLevelValue = 1;
            speedLevelValue = 1;
        }
        speedLevelText.text = "Speed :" + speedLevelValue;
        healthLevelText.text = "Health : " + healthLevelValue;
        speedPriceText.text = "Price : " + speedPriceValue;
        healthPriceText.text = "Health : " + healthLevelValue;
    }

    private void Update()
    {
        speedPriceValue = speedLevelValue * 5;
        healthPriceValue = healthLevelValue * 10;

        if (speedLevelValue == 5)
        {
            speedPriceText.text = "MAX";
        }

        if (healthLevelValue == 5)
        {
            healthPriceText.text = "MAX";
        }
        healthLevelText.text = "Health : " + healthLevelValue;
        healthPriceText.text = "Price : " + healthPriceValue;
        speedLevelText.text = "Speed : " + speedLevelValue;
        speedPriceText.text = "Price : " + speedPriceValue;
    }

    public void speedPower()
    {
        if (Information.coinCounter(speedPriceValue))
        {
            if (speedLevelValue <= 4)
            {
                speedLevelValue++;
            }
        }
        // speedLevelText.text = "Speed : " + speedLevelValue;
        // speedPriceText.text = "Price : " + speedPriceValue;
    }

    public void healthPower()
    {
        if (Information.coinCounter(healthPriceValue))
        {
            if (healthLevelValue <= 4)
            {
                healthLevelValue++;
            }
        }
        // healthLevelText.text = "Health : " + healthLevelValue;
        // healthPriceText.text = "Price : " + healthPriceValue;
    }

    public void backMenu()
    {
        PowerUpPanel.SetActive(false);
    }
}
