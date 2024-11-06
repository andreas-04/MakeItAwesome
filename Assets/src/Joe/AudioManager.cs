using UnityEngine;

using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    // AudioManger is a facade of the audioplayer becasue it simplifies the interface for the client
    public static AudioManager Instance { get; private set; }

    // Dynamic Binding with with AudioPlayer class
    // TODO: This needs to be initalized in the constructor of audiomanager class
    private List<AudioPlayer> audioPlayers = new List<AudioPlayer>();

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

        // Initialize audio players
        audioPlayers.Add(new AudioPlayer.BackgroundAudio());
        audioPlayers.Add(new AudioPlayer.SFXAudio());
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

    private bool hasPlayedGroundedSound = false;

    // public void PlaySFX(int clipIndex)
    // {
    //     if (!hasPlayedGroundedSound && clipIndex >= 0 && clipIndex < sfxClips.Count)
    //     {
    //         sfxSource.clip = sfxClips[clipIndex];
    //         sfxSource.Play();
    //         hasPlayedGroundedSound = true;
    //     }
    // }
}
