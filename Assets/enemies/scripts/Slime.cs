using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Slime : MonoBehaviour
{
    private GameObject camera;
    private GameObject player;
    private DestroyObject _destroyObject;
    private SpriteRenderer _spriteRenderer;
    public GameObject target;
    public float speed = 2f;
    public int HP;
    private bool active = true;
    
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _destroyObject = GetComponent<DestroyObject>();
        HP = 10;
        camera = GameObject.Find("Main Camera");
        player = GameObject.FindWithTag("Player");
        target = GameObject.Find("center");
    }
    private IEnumerator delay()
    {
        if (!active)
        {
            yield return new WaitForSeconds(2f);
            active = true;
        }
    }
    
    void Update ()
    {
        if (HP > 0)
        {
            transform.Translate((target.transform.position - transform.position).normalized * (speed*Time.deltaTime));
        }
        if ((target.transform.position - transform.position).normalized.x > 0) 
        { 
            _spriteRenderer.flipX = true;
        }
        else 
        { 
            _spriteRenderer.flipX = false;
        }

        if (HP <= 0 && active)
        {
            
            _destroyObject.enabled = true;
            gameObject.GetComponent<PolygonCollider2D>().enabled = false;
            player.gameObject.GetComponent<enemyGenerator>()._currentEnemyCount--;
            camera.gameObject.GetComponent<Timer>().kills++;
            active = false;
            StartCoroutine(delay());
        }

        if (Math.Abs((target.transform.position - transform.position).x) + Math.Abs((target.transform.position - transform.position).y) > 15)
        {
            _destroyObject.enabled = true;
            if (active)
            {
                player.gameObject.GetComponent<enemyGenerator>()._currentEnemyCount--;
                active = false;
                StartCoroutine(delay());
            }
        }
    }
}