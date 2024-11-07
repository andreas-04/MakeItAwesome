using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    private List<AudioPlayer> audioPlayers = new List<AudioPlayer>();

    public AudioSource backgroundMusicSource; // Reference to the AudioSource for background music
    public AudioSource sfxSource; // Reference to the AudioSource for sound effects

    void Awake()
    {
        // Make the AudioManager persistent across scenes
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // TODO: Will have dynamic binding here

        // Initialize audio players
        var backgroundAudio = new AudioPlayer.BackgroundAudio();
        backgroundAudio.audioSource = backgroundMusicSource;
        audioPlayers.Add(backgroundAudio);

        var sfxAudio = new AudioPlayer.SFXAudio();
        sfxAudio.audioSource = sfxSource;
        audioPlayers.Add(sfxAudio);
    }

    public void PlayAudio(int index)
    {
        if (index >= 0 && index < audioPlayers.Count)
        {
            audioPlayers[index].Play();
        }
        else
        {
            Debug.LogWarning("Invalid audio player index");
        }
    }
}