using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    private bool active = true;
    public enemyGenerator enemyGenerator;

    
    private void Start()
    {
        
    }

    private IEnumerator spawn_delay(int phaseSeconds)
    {
        if (!active)
        {
            yield return new WaitForSeconds(phaseSeconds);
            enemyGenerator._maxEnemyCount = 20;
            enemyGenerator._spawnRate = 0.5f;
            active = true;
        }
    }

    private void Update()
    {
        waveScenario();
    }

    private void waveScenario()
    {
        if (active)
        {
            active = false;
            StartCoroutine(spawn_delay(60));
            
        }
    }


}
