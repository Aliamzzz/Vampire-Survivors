using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    private bool active = true;
    private bool flag = true;
    public enemyGenerator enemyGenerator;

    
    private void Start()
    {
    }

    private IEnumerator spawn_delay(int phaseSeconds, int maxEnemy, float spawnRate)
    {
        if (!active)
        {
            yield return new WaitForSeconds(phaseSeconds);
            enemyGenerator._maxEnemyCount = maxEnemy;
            enemyGenerator._spawnRate = spawnRate;
            active = true;
        }
    }

    private void Update()
    {
        if (GameObject.FindWithTag("Player") != null && flag)
        {
            flag = false;
            enemyGenerator = GameObject.FindWithTag("Player").GetComponent<enemyGenerator>();
        }
        
        waveScenario();
    }

    private void waveScenario()
    {
        if (active)
        {
            active = false;
            StartCoroutine(spawn_delay(60, 20, 0.5f));
        }
    }


}
