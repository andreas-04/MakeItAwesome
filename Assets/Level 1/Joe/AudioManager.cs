using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Background Music")]
    public AudioSource musicSource; // AudioSource for background music
    public AudioClip[] backgroundMusicTracks; // Array to hold different music tracks

    [Header("Sound Effects")]
    public AudioSource sfxSource; // AudioSource for sound effects
    public AudioClip[] sfxClips; // Array to hold different sound effect clips

    void Awake()
    {
        // Make the AudioManager persistent across scenes
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Play a background music track
    public void PlayMusic(int trackIndex)
    {
        if (trackIndex < 0 || trackIndex >= backgroundMusicTracks.Length) return;
        musicSource.clip = backgroundMusicTracks[trackIndex];
        musicSource.Play();
    }

    // Play a sound effect
    public void PlaySFX(int sfxIndex)
    {
        if (sfxIndex < 0 || sfxIndex >= sfxClips.Length) return;
        sfxSource.PlayOneShot(sfxClips[sfxIndex]);
    }

    // Adjust music volume
    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    // Adjust SFX volume
    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }
}
