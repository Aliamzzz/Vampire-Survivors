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
    public Player player;
    private float _healthOfPlayer;
    private float _maxhealt;

    public void initialing()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        _maxhealt = player.HP;
    }

    private void Update()
    {
        if(player != null) {
            _healthOfPlayer = player.HP;

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
    }

    public void takeDamege(float health)
    { 
        bar.fillAmount = health / 150f;
    }

    public void addHealth(int health)
    {
        bar.fillAmount = (_healthOfPlayer + health) / 150f;
    }
}
