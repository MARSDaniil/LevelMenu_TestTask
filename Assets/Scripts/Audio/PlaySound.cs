using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;
    public void PlayOneShoot()
    {
        if (clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

}
