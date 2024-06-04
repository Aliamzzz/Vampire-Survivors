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
    public Fighter hero;
    private float _healthOfPlayer;

    private void Update()
    {
        _healthOfPlayer = hero.HP;
        takeDamege(_healthOfPlayer);
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

    public void takeDamege(float health)
    { 
        bar.fillAmount = health / 150f;
    }
}
