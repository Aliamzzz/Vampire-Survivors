using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{ 
    private float startSecTime = 0;
    private int startMinTime = 0;
    public int kills = 0;
    [SerializeField] private Text timeBox;
    [SerializeField] private Text killBox;
    private bool isMove;
    
    void Start()
    {
        // timeBox.text = startSecTime.ToString("F3");
    }
     
    void Update()
    {
        startSecTime += Time.deltaTime;
        if (Input.anyKey) isMove = true;
        if (startSecTime > 59)
        {
            startSecTime = 0;
            startMinTime++;
        }
        if (isMove)
        {
            timeBox.text = startMinTime + ":" + (int)startSecTime;
            killBox.text = kills.ToString();
        }
    }

}