using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : Player
{

    //public override int hp;
    
    // public Mage() : base(playerSpeed, hp, attackSpeed)
    // {
    //     
    // }

    
    
    // SetPlayerSpeed(4);

    
        
    // public float playerSpeed;
    // public int hp = 70;
    // public int attackSpeed = 1;
    // public int projectiles = 2;
    // public int currentXp = 0;
    // public int maxXp = 500;
    
    private Transform _transform;

    void Start()
    {
        _transform = GetComponent<Transform>();
        this.playerSpeed = 6;
    }

    void Update()
    {
        Movement(playerSpeed, _transform);
    }
}
