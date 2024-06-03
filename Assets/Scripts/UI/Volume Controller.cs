using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [SerializeField] private Scrollbar _scrollbar;
    [SerializeField] private Text muteText;
    void Start()
    {
        _scrollbar.value = 0.5f;
        audioChanger();
        muteText.text = "Music is Playing!";
    }
    
    public void audioChanger()
    {
        AudioListener.volume = _scrollbar.value;
    }

    public void soundButton()
    {
        AudioListener.pause = !AudioListener.pause;
        if (!AudioListener.pause)
        {
            muteText.text = "Music is Playing!";
        }

        else
        {
            muteText.text = "EveryThing is Mute!";
        }
        
    }
}
