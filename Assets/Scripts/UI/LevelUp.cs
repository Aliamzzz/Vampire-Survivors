using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelUp : MonoBehaviour
{

    [SerializeField] private GameObject panel;
    
    private int knifeLevel = 0;
    [SerializeField] public TextMeshProUGUI swordText;
    
    private int swordLevel = 0;
    [SerializeField] public TextMeshProUGUI knifeText;

    private void Update()
    {
        swordText.text = "Sword : " + swordLevel;
        knifeText.text = "Knife : " + knifeLevel;
    }

    public void KnifeSelected()
    {
        if (knifeLevel == 0)
        {
            knifeLevel++;
            Time.timeScale = 1;
            GameObject.FindWithTag("Player").GetComponent<KnifeGenterator>().enabled = true;
            panel.SetActive(false);
        }
        if (knifeLevel >= 1 && knifeLevel < 6)
        {
            knifeLevel++;
            Time.timeScale = 1;
            GameObject.FindWithTag("Player").GetComponent<KnifeGenterator>().knifeFireRate -= 0.29f;
            panel.SetActive(false);
            
        }
    }

    public void SwordSelected()
    {
        swordLevel++;
        Time.timeScale = 1;
        GameObject.Find("weapon generator").GetComponent<WeaponGenerator>().swordFireRate -= 0.29f;
        panel.SetActive(false);
    }
    
    
}
