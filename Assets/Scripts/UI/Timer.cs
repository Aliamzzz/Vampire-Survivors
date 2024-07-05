using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour
{ 
    private float startSecTime = 0;
    private int startMinTime = 0;
    public int kills = 0;
    [SerializeField] private Text timeBox;
    [SerializeField] private Text killBox;
    
    private int xp;
    [SerializeField] private GameObject levelUp;
    void Start()
    {
        // timeBox.text = startSecTime.ToString("F3");
    }
     
    void Update()
    { 
        if (startSecTime > 59)
        {
            startSecTime = 0;
            startMinTime++;
        }
            startSecTime += Time.deltaTime;
            if(startSecTime <= 10) timeBox.text = startMinTime + ":0" + (int)startSecTime;
            else timeBox.text = startMinTime + ":" + (int)startSecTime;
            killBox.text = "Kills : " + kills;

            if (xp == 100)
            {
                Time.timeScale = 0;
                xp = 0;
                levelUp.SetActive(true);
            }
    }

    
}