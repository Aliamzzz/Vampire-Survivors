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
    public int speedPriceValue = 50;
    [SerializeField] private TextMeshProUGUI healthPriceText;
    public int healthPriceValue = 30;
    [SerializeField] private TextMeshProUGUI speedLevelText;
    public int speedLevelValue;
    [SerializeField] private TextMeshProUGUI healthLevelText;
    public int healthLevelValue;

    public void Start()
    {
        speedLevelText.text = "Speed :" + speedLevelValue;
        healthLevelText.text = "Health : " + healthLevelValue;
        speedPriceText.text = "Price : " + speedPriceValue;
        healthPriceText.text = "Health : " + healthLevelValue;
    }

    private void Update()
    {
        if (speedLevelValue == 5)
        {
            speedPriceText.text = "MAX";
        }

        if (healthLevelValue == 5)
        {
            healthPriceText.text = "MAX";
        }
    }

    public void speedPower()
    {
        if (speedLevelValue <= 4)
        {
            speedLevelValue++;
            speedLevelText.text = "Speed :" + speedLevelValue;
            speedPriceValue += 25;
            speedPriceText.text = "Price : " + speedPriceValue;
        }
    }

    public void healthPower()
    {
        if (healthLevelValue <= 4)
        {
            healthLevelValue++;
            healthLevelText.text = "Health :" + healthLevelValue;
            healthPriceValue += 15;
            healthPriceText.text = "Price : " + healthPriceValue;
        }
    }

    public void backMenu()
    {
        PowerUpPanel.SetActive(false);
    }
}
