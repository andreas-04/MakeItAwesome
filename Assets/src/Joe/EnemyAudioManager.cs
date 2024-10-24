using UnityEngine;

public class EnemyAudioManager : AudioManager
{
    [Header("Enemy Sound Effects")]
    public AudioSource enemySFXSource; // Separate AudioSource for enemy-specific sound effects
    public AudioClip[] enemySFXClips; // Array to hold different enemy sound effect clips

    // Play a specific enemy sound effect
    public void PlayEnemySFX(int sfxIndex)
    {
        if (sfxIndex < 0 || sfxIndex >= enemySFXClips.Length) return;
        enemySFXSource.PlayOneShot(enemySFXClips[sfxIndex]);
    }

    // Adjust enemy SFX volume
    public void SetEnemySFXVolume(float volume)
    {
        enemySFXSource.volume = volume;
    }
}
