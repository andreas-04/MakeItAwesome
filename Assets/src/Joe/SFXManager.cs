using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : AudioManager
{

    [Header("SFX Audio Source")]
    public AudioSource sfxSource;

    [Header("Sound Effects")]
    public List<AudioClip> sfxClips; // Array to hold different sound effect clips

    private bool hasPlayedGroundedSound = false;

    public void PlaySFX(int clipIndex)
    {
        if (!hasPlayedGroundedSound && clipIndex >= 0 && clipIndex < sfxClips.Count)
        {
            sfxSource.clip = sfxClips[clipIndex];
            sfxSource.Play();
            hasPlayedGroundedSound = true;
        }
    }
}
