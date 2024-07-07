using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Unity.Mathematics;

public class Enemy : MonoBehaviour
{
    private GameObject camera;
    private GameObject player;
    private DestroyObject _destroyObject;
    private SpriteRenderer _spriteRenderer;
    public GameObject target;
    public WaveManager waveManager;
    public float speed = 2f;
    public int HP;
    private bool active = true;

    [SerializeField] private GameObject GEM;
    [SerializeField] private GameObject heart;

    public bool leftSprite;
    
    private void Start()
    {
        waveManager = GameObject.Find("EventSystem").GetComponent<WaveManager>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _destroyObject = GetComponent<DestroyObject>();
        //HP = 10;
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

        if (leftSprite)
        {
            if ((target.transform.position - transform.position).normalized.x > 0)
            {
                _spriteRenderer.flipX = true;
            }
            else
            {
                _spriteRenderer.flipX = false;
            }
        }
        else
        {
            if ((target.transform.position - transform.position).normalized.x > 0)
            {
                _spriteRenderer.flipX = false;
            }
            else
            {
                _spriteRenderer.flipX = true;
            }
        }

        if (HP <= 0 && active)
        {
            
            _destroyObject.enabled = true;
            int rnd = UnityEngine.Random.Range(0, 13);
            if (rnd % 5 == 0)
            {
                Instantiate(heart, gameObject.transform.position, Quaternion.identity);
            }
            
            Instantiate(GEM, gameObject.transform.position, Quaternion.identity);
            gameObject.GetComponent<PolygonCollider2D>().enabled = false;
            waveManager._currentEnemyCount--;
            camera.gameObject.GetComponent<Timer>().kills++;
            active = false;
            StartCoroutine(delay());
        }

        if (Math.Abs((target.transform.position - transform.position).x) + Math.Abs((target.transform.position - transform.position).y) > 15)
        {
            _destroyObject.enabled = true;
            if (active)
            {
                waveManager._currentEnemyCount--;
                active = false;
                StartCoroutine(delay());
            }
        }
    }
}