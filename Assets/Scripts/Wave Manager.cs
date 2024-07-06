using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public int _currentEnemyCount = 0;
    private bool active1 = true;
    private bool active2 = false;
    public slimeGenerator slimeGenerator;
    public ghoulGenerator ghoulGenerator;
    private Menu menu;
    
    

    private IEnumerator set_slime(int phaseSeconds, int maxEnemy, float spawnRate, bool active)
    {
        if (!active1)
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
        if (!active1)
        {
            yield return new WaitForSeconds(phaseSeconds);
            ghoulGenerator._maxEnemyCount = maxEnemy;
            ghoulGenerator._spawnRate = spawnRate;
            ghoulGenerator.enabled = active;
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
        }

        if (menu.intoTheGame)
        {
            Wave1();
        }
    }

    private void Wave1()
    {
        if (active1 && !active2)
        {
            active1 = false;
            StartCoroutine(set_slime(15, 10, 1.5f, false));
            StartCoroutine(set_ghoul(15, 10, 1.5f, true));
        }
        if (active2 && active1)
        {
            active1 = false;
            StartCoroutine(set_slime(30, 20, 0.5f, true));
            StartCoroutine(set_ghoul(30, 20, 1.75f, true));
        }
    }


}
