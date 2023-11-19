using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManagerScript : MonoBehaviour
{

    public Toggle musicToggle;
    public Toggle sfxToggle;
    public AudioSource aud;
    public AudioClip klip;


    // Start is called before the first frame update
    void Start()
    {

        if (PlayerPrefs.GetInt("IsMusicOn") == 1)
        {
            musicToggle.isOn = true;
        }
        else
        {
            musicToggle.isOn = false;
        }

        if (PlayerPrefs.GetInt("IsSFXOn") == 1)
        {
            sfxToggle.isOn = true;
        }
        else
        {
            sfxToggle.isOn = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MuteMusic()
    {
        if (musicToggle.isOn == true)
        {
            PlayerPrefs.SetInt("IsMusicOn", 1);
            aud.clip = klip;
            aud.Play();
        }
        else
        {
            PlayerPrefs.SetInt("IsMusicOn", 0);
            aud.clip = klip;
            aud.Pause();
        }
    }

    public void MuteSFX()
    {
        if (sfxToggle.isOn == true)
        {
            PlayerPrefs.SetInt("IsSFXOn", 1);
        }
        else
        {
            PlayerPrefs.SetInt("IsSFXOn", 0);
        }
    }
}
