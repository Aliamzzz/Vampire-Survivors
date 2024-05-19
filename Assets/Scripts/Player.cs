using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed;
    private Transform _transform;
    void Start()
    {
        _transform = GetComponent<Transform>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            _transform.position += new Vector3(0, playerSpeed, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            _transform.position += new Vector3(0, -playerSpeed, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            _transform.position += new Vector3(-playerSpeed, 0, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            _transform.position += new Vector3(playerSpeed, 0, 0) * Time.deltaTime;
        }
    }
}
