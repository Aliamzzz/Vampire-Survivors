using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
public class knife : MonoBehaviour
{
    private Transform _transform;
    public float knifeSpeed;
    private DestroyObject _destroyObject;
    private GameObject player;
    
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        _destroyObject = GetComponent<DestroyObject>();
        _transform = GetComponent<Transform>();
    }
    void Update()
    {
        if (Math.Abs((player.transform.position - transform.position).x) +
            Math.Abs((player.transform.position - transform.position).y) > 15)
        {
            Destroy (gameObject, 0);
        }
        _transform.position += (_transform.rotation * Quaternion.Euler(0,0,45)) * Vector3.one  * (knifeSpeed * Time.deltaTime);
    }
}
