using UnityEngine;

using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    public AudioSource musicSource; // AudioSource for background music

    [Header("Background Music")]

    public AudioClip backgroundMusic;
    private bool hasPlayedGroundedSound = false;

    [Header("Sound Effects")]
    public List<AudioClip> sfxClips; // Array to hold different sound effect clips

    void Awake()
    {
        // Make the AudioManager persistent across scenes
        if (Instance == null)
        {
            musicSource.clip = backgroundMusic;
            musicSource.Play();
            Instance = this;
            // DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Play a sound effect
    public void PlaySFX(int clipIndex)
    {
        if (!hasPlayedGroundedSound && clipIndex >= 0 && clipIndex < sfxClips.Count)
        {
            musicSource.clip = sfxClips[clipIndex];
            musicSource.Play();
            hasPlayedGroundedSound = true;
        }
    }

    // Adjust music volume
    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }
}
