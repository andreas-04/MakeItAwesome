using UnityEngine;
using System.Collections.Generic;

public class AudioPlayer
{
    public AudioSource audioSource; // AudioSource for playing audio

    public virtual void Play()
    {
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
            Debug.Log("Playing audio");
        }
        else
        {
            Debug.LogWarning("AudioSource or AudioClip is not set");
        }
    }

    public class BackgroundAudio : AudioPlayer
    {
        public override void Play()
        {
            if (audioSource != null && audioSource.clip != null)
            {
                audioSource.loop = true;
                audioSource.Play();
                Debug.Log("Playing background audio");
            }
            else
            {
                Debug.LogWarning("AudioSource or AudioClip is not set");
            }
        }
    }

    public class SFXAudio : AudioPlayer
    {
        public override void Play()
        {
            if (audioSource != null && audioSource.clip != null)
            {
                audioSource.loop = false;
                // audioSource.Play();
                Debug.Log("Playing SFX audio");
            }
            else
            {
                Debug.LogWarning("AudioSource or AudioClip is not set");
            }
        }
    }
}