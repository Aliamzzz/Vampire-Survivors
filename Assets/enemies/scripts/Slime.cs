using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Slime : MonoBehaviour
{

    //private Rigidbody2D _rigidbody2D;
    //private Player player;
    private SpriteRenderer _spriteRenderer;
    public GameObject target;
    public float speed = 2f;

    public int HP = 10;
    // private Vector3 directionToPlayer;
    // private Vector3 localScale;
    //
    private void Start()
    {
        target = GameObject.Find("center");
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    void Update ()
    {
        transform.Translate((target.transform.position - transform.position).normalized * (speed*Time.deltaTime));
        if((target.transform.position - transform.position).normalized.x > 0) 
        { 
            _spriteRenderer.flipX = true;
        }
        else 
        { 
            _spriteRenderer.flipX = false;
        }
    }
}
