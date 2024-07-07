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
            int hpEnemy = other.gameObject.GetComponent<Enemy>().HP - 10;
            other.gameObject.GetComponent<Enemy>().HP -= 10;
            other.gameObject.GetComponent<Animator>().SetInteger("HP", hpEnemy);
        }
    }
}
