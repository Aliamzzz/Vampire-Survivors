using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour
{

    public Transform transform;
    
    public float playerSpeed;
    
    public Animator animator;

    public bool lookLeft;

    public Camera mainCamera;

    public void Movement(float playerSpeed, Transform _transform)
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            _transform.position += new Vector3(0, playerSpeed, 0) * Time.deltaTime;
            mainCamera.transform.position += new Vector3(0, playerSpeed, 0) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            _transform.position += new Vector3(0, -playerSpeed, 0) * Time.deltaTime;
            mainCamera.transform.position += new Vector3(0, -playerSpeed, 0) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            lookLeft = true;
            _transform.position += new Vector3(-playerSpeed, 0, 0) * Time.deltaTime;
            mainCamera.transform.position += new Vector3(-playerSpeed, 0, 0) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            lookLeft = false;
            _transform.position += new Vector3(playerSpeed, 0, 0) * Time.deltaTime;
            mainCamera.transform.position += new Vector3(playerSpeed, 0, 0) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)
            || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool("move", true);
        }
        else
        {
            animator.SetBool("move", false);
        }
    }
}