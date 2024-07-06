using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EarnCoin : MonoBehaviour
{

    private Menu _menu;

    private void Start()
    {
        _menu = GameObject.FindWithTag("pause").GetComponent<Menu>();
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _menu.addCoin(); // increment the coin count
            Destroy(gameObject); // destroy the coin
        }
    }
}
