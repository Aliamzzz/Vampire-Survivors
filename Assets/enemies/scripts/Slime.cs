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
    
    private void Start()
    {
        _destroyObject = GetComponent<DestroyObject>();
        HP = 10;
        camera = GameObject.Find("Main Camera");
        player = GameObject.Find("player");
        target = GameObject.Find("center");
        
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    void Update ()
    {
        if (HP > 0 && HP < 100000)  //sharte dovom baraye mast maalie ye buge
        {
            transform.Translate((target.transform.position - transform.position).normalized * (speed*Time.deltaTime));
        }
        if((target.transform.position - transform.position).normalized.x > 0) 
        { 
            _spriteRenderer.flipX = true;
        }
        else 
        { 
            _spriteRenderer.flipX = false;
        }

        if (HP <= 0)
        {
            _destroyObject.enabled = true;
            player.gameObject.GetComponent<enemyGenerator>()._currentEnemyCount--;
            camera.gameObject.GetComponent<Timer>().kills++;
            HP = 100000;  //inam bara mast malie bug oomade
        }

        if ((target.transform.position - transform.position).x + (target.transform.position - transform.position).y > 20)
        {
            _destroyObject.enabled = true;
            player.gameObject.GetComponent<enemyGenerator>()._currentEnemyCount--;
        }
    }
}
