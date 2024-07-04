using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageToPlayer : MonoBehaviour
{
    private float damage;
    //private bool active = true;
    [SerializeField] private GameObject player;
    private GameObject slime;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        damage = 0.3f;
    }

    private void Update()
    {
        if (gameObject.GetComponent<PolygonCollider2D>().IsTouching(player.GetComponent<BoxCollider2D>()))
        {
            float hpPlayer = player.gameObject.GetComponent<Player>().HP - damage;
            player.gameObject.GetComponent<Player>().HP -= damage;
            player.gameObject.GetComponent<Animator>().SetFloat("HP", hpPlayer);
        }
    }
}
