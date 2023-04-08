using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{

    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string MusicPref = "MusicPref";
    private static readonly string SoundEffectsPref = "SoundEffectsPref";
    private int firstPlayInt;
    public int musicInt, soundEffectsInt;
    
    public AudioSource[] musicAudio;
    public AudioSource[] soundEffectsAudio;
    // Start is called before the first frame update
    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        if(firstPlayInt == 0)
        {
            musicInt = 1;
            soundEffectsInt = 1;
            PlayerPrefs.SetInt(MusicPref, musicInt);
            PlayerPrefs.SetInt(SoundEffectsPref, soundEffectsInt);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
            musicInt = PlayerPrefs.GetInt(MusicPref);
            soundEffectsInt = PlayerPrefs.GetInt(SoundEffectsPref);
        }
    }

    public void SaveSoundSettings()
    {
        PlayerPrefs.SetInt(MusicPref, musicInt);
        PlayerPrefs.SetInt(SoundEffectsPref, soundEffectsInt);
    }

    void OnApplicationFocus(bool inFocus)
    {
        if (!inFocus)
        {
            SaveSoundSettings();
        }
    }

    public void UpdateSound()
    {
        if(soundEffectsAudio[0].volume == 1)
        {
            for (int i = 0; i < soundEffectsAudio.Length; i++)
            {
                soundEffectsAudio[i].volume = 0;
            }
        }
        else
        {
            for (int i = 0; i < soundEffectsAudio.Length; i++)
            {
                soundEffectsAudio[i].volume = 1;
            }
        }
    }

    public void UpdateMusic()
    {
        if (musicInt == 1)
        {

            for (int i = 0; i < musicAudio.Length; i++)
            {
                musicAudio[i].volume = 0;
            }
        }
        else
        {
            for (int i = 0; i < musicAudio.Length; i++)
            {
                musicAudio[i].volume = 1;
            }
        }
    }




}
    
    
        
    

