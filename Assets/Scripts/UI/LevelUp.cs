using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelUp : MonoBehaviour
{

    [SerializeField] private GameObject panel;
    
    private int speedLevel;
    [SerializeField] public TextMeshProUGUI speedText;
    
    private int healthLevel;
    [SerializeField] public TextMeshProUGUI healthText;
    
    public void helathSelected()
    {
        if (healthLevel < 5)
        {
            healthLevel++;
            healthText.text = "Health : " + healthLevel;
        }
        else
        {
            healthText.text = "Max Level";
        }
        Time.timeScale = 1;
        panel.SetActive(false);
    }

    public void speedSelected()
    {
        if (speedLevel < 5)
        {
            speedLevel++;
            speedText.text = "Speed : " + speedLevel;
        }
        else
        {
            speedText.text = "Max Level";
        }
        Time.timeScale = 1;
        panel.SetActive(false);

    }
    
    
}
