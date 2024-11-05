using UnityEngine;

using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{

    // TODO: Create dynamic binding with subclass with virtual for PlaySFX()
    public static AudioManager Instance { get; private set; }


    [Header("AudioManager Source")]
    public AudioSource musicSource; // AudioSource for background music

    [Header("Background Music")]
    public AudioClip backgroundMusic;

    void Awake()
    {
        // Make the AudioManager persistent across scenes
        if (Instance == null)
        {
            musicSource.clip = backgroundMusic;
            musicSource.Play();
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Adjust music volume
    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }
}
