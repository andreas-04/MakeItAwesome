using UnityEngine;
using System.Collections.Generic;

public class AudioPlayer
{
    private AudioSource audioSource; // AudioSource for playing audio

    private List<AudioClip> audioClips; // List to hold audio clips

    public virtual void Play(int clip)
    // public void Play(int clip)
    {
        Debug.Log("Playing superclass audio");
        audioSource.clip = audioClips[0];
        audioSource.Play();

    }

    public void SetAudioSource(AudioSource source)
    {
        audioSource = source;
    }

    public void SetAudioClips(List<AudioClip> clips)
    {
        audioClips = clips;
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