using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarnGem : MonoBehaviour
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
            _menu.addXP(); // increment the xp count
            Destroy(gameObject); // destroy the xp
        }
    }
}
