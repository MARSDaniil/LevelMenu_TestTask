using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundMusicManger : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    public string SoundPref;
    private int firstPlayInt;
    public int soundInt;
    
    public AudioSource[] soundAudio;

    public GameObject soundOn;
    public GameObject soundOff;

    // Start is called before the first frame update
    private void Start()
    {
        
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        if(firstPlayInt == 0)
        {
            soundInt = 1;
            PlayerPrefs.SetInt(SoundPref, soundInt);
            
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
            soundInt = PlayerPrefs.GetInt(SoundPref);
           
        }
      
        SetValueToSound(soundInt, soundAudio);
    
        SaveSoundSettings(soundInt, SoundPref);
        SetStartIcon(soundOn, soundOff, soundInt);
     
    }


    //включение и выключение иконок звука в зависимости от сохранения музыки/звуков
    private void SetStartIcon(GameObject active, GameObject disActive, int value) 
    {
        switch(value)
        {
            case 0:
                disActive.SetActive(true);
                active.SetActive(false);
                return;
            case 1:
                disActive.SetActive(false);
                active.SetActive(true);
                return;
        }
    }


    //сохранение значения включенности/выключенности звуков и музыки 
    private void SaveSoundSettings(int volumeInt, string soundName) 
    {
        PlayerPrefs.SetInt(soundName, volumeInt);
    }

    //проверка звука у первого(читать любого) звука из массива и переключение его на противоположное значение
    private void UpdateSound(AudioSource[] sound, string soundName)
    {
        int musicalOrSoundInt;
     //   Debug.Log("Music value last=" + sound[0].volume);
        if (sound[0].volume == 1)
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
  //      Debug.Log("musicInt = " + musicalOrSoundInt);

        
        SaveSoundSettings(musicalOrSoundInt, soundName);
    //    Debug.Log("ImportMusicInt =" + PlayerPrefs.GetInt(MusicPref));
    
    }

  //установка одного значения для всех элементов массива звуков
    private void SetValueToSound(int value, AudioSource[] arrAudio)
    {
        for (int i = 0; i < arrAudio.Length; i++)
        {
            arrAudio[i].volume = value;
        }
    }
    //открытые методы использования 


    public void UpdateMusicsEffects()
    {
        UpdateSound(soundAudio, SoundPref);
     
    }

    public void PlayBoop()
    {
        PlayOneShoot(soundAudio, 0);
    }
    private void PlayOneShoot(AudioSource[] arrAudio, int index)
    {
        arrAudio[index].Play();
    }

}


  





