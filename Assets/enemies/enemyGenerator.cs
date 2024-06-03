using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Random = UnityEngine.Random;

public class enemyGenerator : MonoBehaviour
{
    public Transform player;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private int _maxEnemyCount;
    private int _currentEnemyCount;
    [SerializeField] private float _spawnRate = 1.5f;
    [SerializeField] private float dangerRadius = 3.0f;
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
        if (_canSpawn && _currentEnemyCount < _maxEnemyCount)
        {
            Instantiate(_enemy, GetRandomPosition(dangerRadius), quaternion.identity);
            _currentEnemyCount++;
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
