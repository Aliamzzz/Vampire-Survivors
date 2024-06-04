using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fighter : Player
{
    private Transform _transform;
    public float HP;
    
    private void Awake()
    {
        HP = 150;
        _transform = GetComponent<Transform>();
        this.playerSpeed = 3;
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        transform = GetComponent<Transform>();
    }

    void Update()
    {
        Movement(playerSpeed, _transform);
        Camera.main.transform.position = new Vector3(_transform.position.x , _transform.position.y , -1.9728f);
        if (lookLeft)
        {
            transform.rotation = new Quaternion(0, 180, 0, 0);
        }
        else
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
    }
}
