using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : Player
{
//     public float playerSpeed = 3;
//     public int hp = 150;
//     public int attackSpeed = 1;
//     public int projectiles = 1;
//     public int currentXp = 0;
//     public int maxXp = 500;
    private Transform _transform;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        this.playerSpeed = 3;
    }

    void Start()
    {
        
    }

    void Update()
    {
        Movement(playerSpeed, _transform);
    }
}
