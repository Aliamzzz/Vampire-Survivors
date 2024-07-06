using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject coin;
    [SerializeField] private float radius = 5.0f;
    public Transform player;
    public int max;
    public int current;
    public float _spawnRate = 5f;
    private bool _canSpawn = true;

    

    private IEnumerator spawn_delay()
    {
        if (!_canSpawn)
        {
            yield return new WaitForSeconds(_spawnRate);
            _canSpawn = true;
        }
    }

    private void Update()
    {
        if (_canSpawn && current < max)
        {
            Instantiate(coin, GetRandomPosition(radius), quaternion.identity);
            current++;
            _canSpawn = false;
            StartCoroutine(spawn_delay());
        }
    }


    public Vector2 GetRandomPosition(float radius)
    {
        Vector2 randomPos = new Vector2(player.position.x + Random.Range(-50, 50), player.position.y + Random.Range(-50, 50));
        while (Vector2.Distance(randomPos, player.position) < radius)
        {
            randomPos = new Vector2(player.position.x + Random.Range(-50, 50), player.position.y + Random.Range(-44, 44));
        }
        return randomPos;
    }
    
}
