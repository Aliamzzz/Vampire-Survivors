using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Timeline;
using Object = System.Object;

public class KnifeGenterator : MonoBehaviour
{

    public float time;
    public float knifeFireRate;
    public Transform firePoint;
    [SerializeField] private Player player;
    [SerializeField] private GameObject knife;
    [SerializeField] private GameObject sound;
    [SerializeField] private float knifeSpeed;
    private float _angel = 0;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    private void Update()
    {
        Vector3 direction = new Vector3(0,0,0);
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
        direction.Normalize();
        if (!direction.Equals(Vector3.zero))
        {
            _angel = math.degrees(math.atan2(-direction.x, direction.y));
        }
        Spawn(_angel);
    }

    private void Spawn(float angel)
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            sound.SetActive(true);
        }
        
        if (time <= 0)
        {
            sound.SetActive(false);
            Instantiate(knife, transform.position, Quaternion.Euler(0, 0, angel));
            time = knifeFireRate;
        }
    }
}
