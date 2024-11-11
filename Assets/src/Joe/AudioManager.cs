using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    private List<AudioPlayer> audioPlayers = new List<AudioPlayer>();

    public AudioSource sfxSource; // Reference to the AudioSource for sound effects
    public AudioSource backgroundMusicSource; // Reference to the AudioSource for background music


    public List<AudioClip> sfxClips; // List to hold audio clips
    public List<AudioClip> audioClips; // List to hold audio clips


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
        // Index 0
        AudioPlayer sfxAudio = new AudioPlayer.SFXAudio();
        sfxAudio.audioSource = sfxSource;
        sfxAudio.audioClips = sfxClips;
        audioPlayers.Add(sfxAudio);

        // Index 1
        AudioPlayer backgroundAudio = new AudioPlayer.BackgroundAudio();
        backgroundAudio.audioSource = backgroundMusicSource;
        backgroundAudio.audioClips = audioClips; // Initialize the list of audio clips
        audioPlayers.Add(backgroundAudio);
    }

    public void PlayAudio(int index, int clip)
    {
        if (index >= 0 && index < audioPlayers.Count)
        {
            audioPlayers[index].Play(clip);
            Debug.Log("Playing audiomanager audio");
        }
        else
        {
            Debug.LogWarning("Invalid audio player index");
        }
    }
}