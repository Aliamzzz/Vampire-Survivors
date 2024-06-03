using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image bar;
    [SerializeField] private GameObject fullHeart;
    [SerializeField] private GameObject halfHeart;
    private Fighter hero;
    private int _healthOfPlayer = 150;

    private void Update()
    {
        if(Input.GetKey(KeyCode.Space)) takeDamege(2);
        if (_healthOfPlayer > 80)
        {
            fullHeart.SetActive(true);
            halfHeart.SetActive(false);
        }
        else
        {
            fullHeart.SetActive(false);
            halfHeart.SetActive(true);
        }
    }

    public void takeDamege(int damage)
    {
        _healthOfPlayer -= damage;
        bar.fillAmount = _healthOfPlayer / 150f;
    }
}
