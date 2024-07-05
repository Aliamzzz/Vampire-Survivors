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

    public void initialing()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
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
}
