using UnityEngine;
using System.Collections.Generic;

public class AudioPlayer
{
    public AudioSource audioSource; // AudioSource for playing audio

    public List<AudioClip> audioClips; // List to hold audio clips

    public virtual void Play(int clip)
    // public void Play(int clip)
    {
        Debug.Log("Playing superclass audio");
        audioSource.clip = audioClips[0];
        audioSource.Play();

    }

    public class BackgroundAudio : AudioPlayer
    {
        public override void Play(int clip)
        // public void Play(int clip)
        {
            Debug.Log("Playing background music");
            audioSource.loop = true;
            audioSource.clip = audioClips[clip];
            audioSource.Play();
        }
    }

    public class SFXAudio : AudioPlayer
    {
        public override void Play(int clip)
        // public void Play(int clip)
        {
            Debug.Log("Playing SFX audio");
            audioSource.loop = false;
            audioSource.clip = audioClips[clip];
            audioSource.Play();
        }
    }
}