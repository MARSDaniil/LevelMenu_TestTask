using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[SerializeField]
public class Sound
{
    public static string SoundPref;
    public int SoundInt;
    public AudioSource[] SoundAudio;
    public GameObject SoundOn;
    public GameObject SoundOff;

  
}


public class VolumeManager : MonoBehaviour
{
    Sound music = new Sound();


    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string MusicPref = "MusicPref";
    private static readonly string SoundEffectsPref = "SoundEffectsPref";
    private int firstPlayInt;
    public int musicInt, soundEffectsInt;
    
    public AudioSource[] musicAudio;
    public AudioSource[] soundEffectsAudio;

    public GameObject musicOn;
    public GameObject musicOff;
    public GameObject soundOn;
    public GameObject soundOff;

    // Start is called before the first frame update
    private void Start()
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
        SetStartIcon(musicOn, musicOff, musicInt);
        SetStartIcon(soundOn, soundOff, soundEffectsInt);
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
    private void UpdateSound(AudioSource[] sound, int musicalOrSoundInt, string soundName)
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
    public void UpdateSoundsEffects()
    {
        UpdateSound(soundEffectsAudio, soundEffectsInt, SoundEffectsPref);
    }

    public void UpdateMusicsEffects()
    {
        UpdateSound(musicAudio, musicInt, MusicPref);
     
    }

    public void PlayBoop()
    {
        PlayOneShoot(soundEffectsAudio, 0);
    }
    private void PlayOneShoot(AudioSource[] arrAudio, int index)
    {
        arrAudio[index].Play();
    }

}


  





