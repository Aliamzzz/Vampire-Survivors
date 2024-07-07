using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Random = UnityEngine.Random;

public class alienGenerator : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private float dangerRadius = 3.0f;
    public Transform player;
    public int _maxEnemyCount;
    public WaveManager waveManager;
    public float _spawnRate = 1.5f;
    private bool _canSpawn = true;

    private void Start()
    {
        waveManager = GameObject.Find("EventSystem").GetComponent<WaveManager>();
    }

    private void Update()
    {
        if (_canSpawn && waveManager._currentEnemyCount < _maxEnemyCount)
        {
            Instantiate(enemy, GetRandomPosition(dangerRadius), quaternion.identity);
            waveManager._currentEnemyCount++;
            _canSpawn = false;
            StartCoroutine(spawn_delay());
        }
    }

    private IEnumerator spawn_delay()
    {
        if (!_canSpawn)
        {
            yield return new WaitForSeconds(_spawnRate);
            _canSpawn = true;
        }
    }


    public Vector2 GetRandomPosition(float radius)
    {
        Vector2 randomPos = new Vector2(player.position.x + Random.Range(-10, 10), player.position.y + Random.Range(-10, 10));
        while (Vector2.Distance(randomPos, player.position) < radius)
        {
            randomPos = new Vector2(player.position.x + Random.Range(-10, 10), player.position.y + Random.Range(-4, 4));
        }
        return randomPos;
    }
}
