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
        muteText.text = "Music is Playing!";
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            load();
            audioChanger();
        }
        else
        {
            load();
            audioChanger();
        }
    }
    
    public void audioChanger()
    {
        AudioListener.volume = _scrollbar.value;
        save();
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

    private void load()
    {
        _scrollbar.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void save()
    {
        PlayerPrefs.SetFloat("musicVolume", _scrollbar.value);
    }
}
