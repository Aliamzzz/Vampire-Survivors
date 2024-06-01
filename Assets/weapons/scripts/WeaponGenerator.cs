using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Object = System.Object;

public class WeaponGenerator : MonoBehaviour
{

    public float time;
    public float swordFireRate;
    public Transform firePoint;
    [SerializeField] private Player player;
    [SerializeField] private GameObject sword;

    private void Update()
    {
        Spawn();
    }

    private void Start()
    {
    }

    private void Spawn()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }

        if (time <= 0)
        {
            if (player.lookLeft)
            {
                Instantiate(sword, transform.position,  Quaternion.identity);
            }
            else
            {
                Instantiate(sword, transform.position,  new Quaternion(0,180,0,0));
            }
            time = swordFireRate;
        }
    }
}