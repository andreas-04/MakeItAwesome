using NUnit.Framework;
using UnityEngine;

public class JOE_AudioManagerTests
{
    private AudioManager audioManager;
    
    [SetUp]
    public void SetUp()
    {
        // Create a GameObject and attach AudioManager
        GameObject audioManagerObject = new GameObject();
        audioManager = audioManagerObject.AddComponent<AudioManager>();
        
        // Set up AudioSource components
        audioManager.musicSource = audioManagerObject.AddComponent<AudioSource>();
        audioManager.sfxSource = audioManagerObject.AddComponent<AudioSource>();

        // Set up audio clips
        audioManager.backgroundMusicTracks = new AudioClip[1]; // 1 track for testing
        audioManager.sfxClips = new AudioClip[1]; // 1 SFX clip for testing
    }

    [Test]
    public void PlayMusic_IndexNegative_ShouldNotPlayMusic()
    {
        // Test that calling PlayMusic with a negative index doesn't play any music
        audioManager.PlayMusic(-1);

        Assert.IsFalse(audioManager.musicSource.isPlaying, "Music should not play when an invalid index is used.");
    }

        [Test]
    public void PlaySFX_IndexOutOfBounds_ShouldNotPlaySFX()
    {
        // Test that calling PlaySFX with an index greater than the array size does not play the SFX
        audioManager.PlaySFX(10); // Assuming the array size is 1, index 10 is out of bounds

        Assert.IsFalse(audioManager.sfxSource.isPlaying, "SFX should not play when index is out of bounds.");
    }

        [Test]
    public void StressTest_PlayMultipleSFX_ShouldHandleWithoutIssues()
    {
        // Set up multiple SFX clips for testing
        int numClips = 1000;
        audioManager.sfxClips = new AudioClip[numClips];
        for (int i = 0; i < numClips; i++)
        {
            audioManager.sfxClips[i] = AudioClip.Create($"Clip{i}", 44100, 1, 44100, false);
        }

        // Play all SFX clips in quick succession
        for (int i = 0; i < numClips; i++)
        {
            audioManager.PlaySFX(i);
        }

        // We can't easily check if all clips are playing since PlayOneShot doesn't set isPlaying,
        // but we can ensure there were no exceptions/errors thrown.
        Assert.Pass("Stress test completed without exceptions.");
    }
}
