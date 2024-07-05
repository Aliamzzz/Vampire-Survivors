using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelBar : MonoBehaviour
{
    [SerializeField] private Image bar;
    [SerializeField] private TextMeshProUGUI coins;
    private int coinNum;
    void Awake()
    {
        coinNum = 0;
    }

    void Update()
    {
        // bar.fillAmount = _fighter.HP / 150f;
        // if (Input.GetKey(KeyCode.CapsLock))
        // {
        //     addCoin();
        // }
    }

    public void addCoin()
    {
        coinNum++;
        coins.text = "Coins : " + coinNum;
    }
}
