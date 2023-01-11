using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Toggle muteBtn;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        var obj = FindObjectsOfType<AudioManager>();
        if (obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        //muteBtn = FindObjectOfType<Toggle>();
        muteBtn = GameObject.Find("Mute").GetComponent<Toggle>();

        //CheckMute(muteBtn);
    }

    public void CheckMute(Toggle toggle)
    {
        if (AudioListener.volume == 0) toggle.isOn = true;
        else toggle .isOn = false;
    }

    public void Mute(bool ismute)
    {
        if (ismute)
        {
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = 1;
        }
    }
}
