using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
    
    public Transform transform;
    
    public float playerSpeed;
    
    public Animator animator;

    [HideInInspector] public bool lookLeft;

    public Camera mainCamera;
    
    

    public void Movement(float playerSpeed, Transform _transform)
    {
        Vector3 direction = new Vector3(0,0,0);
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
        direction.Normalize();
        _transform.position += direction * (playerSpeed * Time.deltaTime);
        mainCamera.transform.position += direction * (playerSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.S) ||
            Input.GetKey(KeyCode.DownArrow) ||
            Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.D) ||
            Input.GetKey(KeyCode.RightArrow))
        {
            if (!((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) &&
                  (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))))
            {
                if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                {
                    lookLeft = false;
                }

                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                {
                    lookLeft = true;
                }
            }
            animator.SetBool("move", true);
        }
        else
        {
            animator.SetBool("move", false);
        }
    }
    
}