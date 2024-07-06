using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EarnHeart : MonoBehaviour
{
    private Player player;
    public HealthBar healthBar;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        healthBar = GameObject.Find("HealthBarManager").GetComponent<HealthBar>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.HP += 5; 
            Destroy(gameObject);
            healthBar.addHealth(5);
        }
    }
}
