using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public int _currentEnemyCount = 0;
    private bool active1 = false;
    private bool active2 = false;
    public slimeGenerator slimeGenerator;
    public ghoulGenerator ghoulGenerator;
    public alienGenerator alienGenerator;
    private Menu menu;
    
    

    private IEnumerator set_slime(int phaseSeconds, int maxEnemy, float spawnRate, bool active)
    {
        if (!active1 && active2)
        {
            yield return new WaitForSeconds(phaseSeconds);
            slimeGenerator._maxEnemyCount = maxEnemy;
            slimeGenerator._spawnRate = spawnRate;
            slimeGenerator.enabled = active;
            //active1 = true;
            active2 = true;
        }
        if (active1 && !active2)
        {
            yield return new WaitForSeconds(phaseSeconds);
            slimeGenerator._maxEnemyCount = maxEnemy;
            slimeGenerator._spawnRate = spawnRate;
            slimeGenerator.enabled = active;
            active1 = true;
            active2 = false;
        }
        if (active1 && active2)
        {
            yield return new WaitForSeconds(phaseSeconds);
            slimeGenerator._maxEnemyCount = maxEnemy;
            slimeGenerator._spawnRate = spawnRate;
            slimeGenerator.enabled = active;
            active1 = true;
            active2 = true;
        }
    }
    private IEnumerator set_ghoul(int phaseSeconds, int maxEnemy, float spawnRate, bool active)
    {
        if (!active1 && active2)
        {
            yield return new WaitForSeconds(phaseSeconds);
            ghoulGenerator._maxEnemyCount = maxEnemy;
            ghoulGenerator._spawnRate = spawnRate;
            ghoulGenerator.enabled = active;
            //active1 = true;
            active2 = true;
        }
        if (active1 && !active2)
        {
            yield return new WaitForSeconds(phaseSeconds);
            ghoulGenerator._maxEnemyCount = maxEnemy;
            ghoulGenerator._spawnRate = spawnRate;
            ghoulGenerator.enabled = active;
            active1 = true;
            active2 = false;
        }
        if (active1 && active2)
        {
            yield return new WaitForSeconds(phaseSeconds);
            ghoulGenerator._maxEnemyCount = maxEnemy;
            ghoulGenerator._spawnRate = spawnRate;
            ghoulGenerator.enabled = active;
            active1 = true;
            active2 = true;
        }
    }
    
    private IEnumerator set_alien(int phaseSeconds, int maxEnemy, float spawnRate, bool active)
    {
        if (!active1 && active2)
        {
            yield return new WaitForSeconds(phaseSeconds);
            alienGenerator._maxEnemyCount = maxEnemy;
            alienGenerator._spawnRate = spawnRate;
            alienGenerator.enabled = active;
            //active1 = true;
            active2 = true;
        }
        if (active1 && !active2)
        {
            yield return new WaitForSeconds(phaseSeconds);
            alienGenerator._maxEnemyCount = maxEnemy;
            alienGenerator._spawnRate = spawnRate;
            alienGenerator.enabled = active;
            active1 = true;
            active2 = false;
        }
        if (active1 && active2)
        {
            yield return new WaitForSeconds(phaseSeconds);
            alienGenerator._maxEnemyCount = maxEnemy;
            alienGenerator._spawnRate = spawnRate;
            alienGenerator.enabled = active;
            active1 = true;
            active2 = true;
        }
    }

    private void Start()
    {
        menu = GameObject.Find("pause").GetComponent<Menu>();
    }

    private void Update()
    {
        if (menu.playerInstantiated)
        {
            menu.playerInstantiated = false;
            slimeGenerator = GameObject.FindWithTag("Player").GetComponent<slimeGenerator>();
            ghoulGenerator = GameObject.FindWithTag("Player").GetComponent<ghoulGenerator>();
            alienGenerator = GameObject.FindWithTag("Player").GetComponent<alienGenerator>();
        }

        if (menu.intoTheGame)
        {
            Waves();
        }
    }

    private void Waves()
    {
        if (!active1 && !active2)
        {
            active2 = true;
            StartCoroutine(set_slime(30, 10, 1.5f, false));
            StartCoroutine(set_ghoul(30, 10, 1.5f, true));
            StartCoroutine(set_alien(30, 10, 1.5f, false));
            // Debug.Log("1");
        }
        if (!active1 && active2)
        {
            active1 = true;
            active2 = false;
            StartCoroutine(set_slime(60, 20, 0.5f, true));
            StartCoroutine(set_ghoul(60, 20, 1.75f, false));
            StartCoroutine(set_alien(60, 10, 1.5f, true));
            // Debug.Log("2");
        }
        if (active1 && !active2)
        {
            active1 = true;
            active2 = true;
            StartCoroutine(set_slime(90, 20, 0.5f, true));
            StartCoroutine(set_ghoul(90, 10, 1.75f, true));
            StartCoroutine(set_alien(90, 10, 1.5f, true));
            // Debug.Log("3");
        }
    }


}