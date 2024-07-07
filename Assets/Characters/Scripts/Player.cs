using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public Transform transform;
    
    private Transform _transform;
    
    public float HP;
    
    public float playerSpeed;
    
    public Animator animator;

    [HideInInspector] public bool lookLeft;

    public Camera mainCamera;

    public bool alive = true;
    
    private void Awake()
    {
        //HP = 150;
        mainCamera = Camera.main;
        _transform = GetComponent<Transform>();
        this.playerSpeed = 3;
    }

    void Start()
    {
        HP = powerUp.healthLevelValue * 25 + 100;
        playerSpeed = (float)(powerUp.speedLevelValue * 0.5) + 3;
        animator = GetComponent<Animator>();
        transform = GetComponent<Transform>();
    }

    void Update()
    {
        if (alive)
        {
            Movement(playerSpeed, _transform);
        }
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