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
        SetValueToSound(soundEffectsInt, soundEffectsAudio);
        SetValueToSound(musicInt, musicAudio);
        SaveSoundSettings(soundEffectsInt, SoundEffectsPref);
        SaveSoundSettings(musicInt, MusicPref);
    }

    public void SaveSoundSettings(int volumeInt, string soundName)
    {
        PlayerPrefs.SetInt(soundName, volumeInt);
    }

    /*
    void OnApplicationFocus(bool inFocus)
    {
        if (!inFocus)
        {
            SaveSoundSettings();
        }
    }
    */

    public void UpdateSound(AudioSource[] sound, int musicalOrSoundInt, string soundName)
    {
     //   Debug.Log("Music value last=" + sound[0].volume);
        if(sound[0].volume == 1)
        {
            SetValueToSound(0, sound);
            musicalOrSoundInt = 0;
        }
        else
        {
            SetValueToSound(1, sound);
            musicalOrSoundInt = 1;

        }
        //     Debug.Log("Music value new =" + sound[0].volume);
        Debug.Log("musicInt = " + musicalOrSoundInt);

        
        SaveSoundSettings(musicalOrSoundInt, soundName);
        Debug.Log("ImportMusicInt =" + PlayerPrefs.GetInt(MusicPref));
    
    }

  
    private void SetValueToSound(int value, AudioSource[] arrAudio)
    {
        for (int i = 0; i < arrAudio.Length; i++)
        {
            arrAudio[i].volume = value;
        }
    }

    public void UpdateSoundsEffects()
    {
        UpdateSound(soundEffectsAudio, soundEffectsInt, SoundEffectsPref);
    }

    public void UpdateMusicsEffects()
    {
        UpdateSound(musicAudio, musicInt, MusicPref);
     
    }
    /*
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

  */


}





