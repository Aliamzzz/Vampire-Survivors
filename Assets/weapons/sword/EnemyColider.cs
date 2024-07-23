using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColider : MonoBehaviour
{

    [SerializeField] private AudioClip hit;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            _audioSource.clip = hit;
            _audioSource.Play();
            int hpEnemy = other.gameObject.GetComponent<Enemy>().HP - 10;
            other.gameObject.GetComponent<Enemy>().HP -= 10;
            other.gameObject.GetComponent<Animator>().SetInteger("HP", hpEnemy);
        }
    }
}
