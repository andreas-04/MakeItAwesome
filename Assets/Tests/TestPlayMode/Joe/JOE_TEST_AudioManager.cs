using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

public class JOE_AudioTests
{
    private GameObject audioManagerObject;
    private AudioManager audioManager;

    [SetUp]
    public void SetUp()
    {
        // Create a new GameObject and add the AudioManager component
        audioManagerObject = new GameObject("AudioManager");
        audioManager = audioManagerObject.AddComponent<AudioManager>();

        // Create and assign AudioSource components
        audioManager.sfxSource = audioManagerObject.AddComponent<AudioSource>();
        audioManager.backgroundMusicSource = audioManagerObject.AddComponent<AudioSource>();

        // Create and assign audio clips
        audioManager.sfxClips = new List<AudioClip> { AudioClip.Create("SFXClip", 44100, 1, 44100, false) };
        audioManager.audioClips = new List<AudioClip> { AudioClip.Create("BackgroundClip", 44100, 1, 44100, false) };
    }

    [TearDown]
    public void TearDown()
    {
        // Destroy the AudioManager GameObject after each test
        Object.Destroy(audioManagerObject);
    }

    [UnityTest]
    public IEnumerator TestSFXPlayContainsMessage()
    {
        // Play the first SFX clip
        audioManager.PlayAudio(0, 0);

        // Wait to ensure the audio plays and the log message has time to appear
        yield return new WaitForSeconds(2);

        LogAssert.Expect(LogType.Warning, "Playing SFX audio");
    }

    [UnityTest]
    public IEnumerator TestBackgroundPlayContainsMessage()
    {
        // Play the first SFX clip
        audioManager.PlayAudio(1, 0);

        // Wait to ensure the audio plays and the log message has time to appear
        yield return new WaitForSeconds(2);

        LogAssert.Expect(LogType.Warning, "Playing background music");
    }

    [UnityTest]
    public IEnumerator TestLogAudioContainsMessage()
    {
        // Play the first SFX clip
        audioManager.PlayAudio(1, 0);

        // Wait to ensure the audio plays and the log message has time to appear
        yield return new WaitForSeconds(2);

        LogAssert.Expect(LogType.Warning, "Playing audiomanager audio");
    }

    [UnityTest]
    public IEnumerator TestOutofBoundSource()
    {
        audioManager.PlayAudio(-1, 0);

        // Wait to ensure the audio plays and the log message has time to appear
        yield return new WaitForSeconds(2);

        LogAssert.Expect(LogType.Warning, "Invalid audio player index");
    }

    [UnityTest]
    public IEnumerator TestOutofBoundSourceAndClip()
    {
        audioManager.PlayAudio(-1, -1);

        // Wait to ensure the audio plays and the log message has time to appear
        yield return new WaitForSeconds(2);

        LogAssert.Expect(LogType.Warning, "Invalid audio player index");
    }

    [UnityTest]
    public IEnumerator TestPlaySFXSuccess()
    {
        audioManager.PlaySFX(0);

        // Wait to ensure the audio plays and the log message has time to appear
        yield return new WaitForSeconds(2);

        LogAssert.Expect(LogType.Warning, "Playing SFX audio");
    }


    [UnityTest]
    public IEnumerator TestPlaySFXFail()
    {
        audioManager.PlaySFX(-1);

        // Wait to ensure the audio plays and the log message has time to appear
        yield return new WaitForSeconds(2);

        LogAssert.Expect(LogType.Warning, "Invalid audio clip index");
    }
}