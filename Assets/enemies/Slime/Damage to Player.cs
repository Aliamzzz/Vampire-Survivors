using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageToPlayer : MonoBehaviour
{
    public float damage;
    private bool active = true;
    [SerializeField] private GameObject player;
    private GameObject slime;

    private void Awake()
    {
        player = GameObject.Find("player");
        damage = 0.3f;
    }

    private void Update()
    {
        if (gameObject.GetComponent<PolygonCollider2D>().IsTouching(player.GetComponent<BoxCollider2D>()))
        {
            float hpPlayer = player.gameObject.GetComponent<Fighter>().HP - damage;
            player.gameObject.GetComponent<Fighter>().HP -= damage;
            player.gameObject.GetComponent<Animator>().SetFloat("HP", hpPlayer);
            //active = false;
            //StartCoroutine(delay());
        }
    }

    // private IEnumerator delay()
    // {
    //     if (!active)
    //     {
    //         yield return new WaitForSeconds(1.5f);
    //         active = true;
    //     }
    // }
    
}
