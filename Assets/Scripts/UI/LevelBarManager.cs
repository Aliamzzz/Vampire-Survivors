using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelBarManager : MonoBehaviour
{
    private Menu _menu;
    [SerializeField] private Image _image;
    private void Start()
    {
        _menu = GameObject.FindWithTag("pause").GetComponent<Menu>();
        
    }

    private void Update()
    {
        _image.fillAmount = (float)_menu.XP / (float)_menu.maxXP;
    }
}

