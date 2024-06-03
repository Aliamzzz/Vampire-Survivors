using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColider : MonoBehaviour
{
    

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            int hp = other.gameObject.GetComponent<Slime>().HP - 10;
            other.gameObject.GetComponent<Slime>().HP -= 10;
            other.gameObject.GetComponent<Animator>().SetInteger("HP", hp);
        }
    }
}
