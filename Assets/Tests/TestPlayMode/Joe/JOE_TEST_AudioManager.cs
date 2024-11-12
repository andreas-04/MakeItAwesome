// // using UnityEngine;
// // using UnityEngine.TestTools;
// // using NUnit.Framework;
// // using System.Collections;
// // using System.Collections.Generic;

// // public class JOE_AudioTests
// // {
// //     private GameObject audioManagerObject;
// //     private AudioManager audioManager;

// //     [SetUp]
// //     public void SetUp()
// //     {
// //         // Create a new GameObject and add the AudioManager component
// //         audioManagerObject = new GameObject("AudioManager");
// //         audioManager = audioManagerObject.AddComponent<AudioManager>();

// //         // Create and assign AudioSource components
// //         audioManager.sfxSource = audioManagerObject.AddComponent<AudioSource>();
// //         audioManager.backgroundMusicSource = audioManagerObject.AddComponent<AudioSource>();

// //         // Create and assign audio clips
// //         audioManager.sfxClips = new List<AudioClip> { AudioClip.Create("SFXClip", 44100, 1, 44100, false) };
// //         audioManager.audioClips = new List<AudioClip> { AudioClip.Create("BackgroundClip", 44100, 1, 44100, false) };

// //         // Initialize the AudioManager
// //         // audioManager.Awake();
// //     }

// //     [TearDown]
// //     public void TearDown()
// //     {
// //         // Destroy the AudioManager GameObject after each test
// //         Object.Destroy(audioManagerObject);
// //     }

// //     [UnityTest]
// //     public IEnumerator TestPlaySFX()
// //     {
// //         // Play the first SFX clip
// //         audioManager.PlayAudio(0, 0);

// //         // Wait for a frame to allow the audio to play
// //         yield return null;

// //         // Assert that the SFX source is playing
// //         Assert.IsTrue(audioManager.sfxSource.isPlaying);
// //     }

// //     [UnityTest]
// //     public IEnumerator TestPlayBackgroundMusic()
// //     {
// //         // Play the first background music clip
// //         audioManager.PlayAudio(1, 0);

// //         // Wait for a frame to allow the audio to play
// //         yield return null;

// //         // Assert that the background music source is playing
// //         Assert.IsTrue(audioManager.backgroundMusicSource.isPlaying);
// //     }

// //     [UnityTest]
// //     public IEnumerator TestStopSFX()
// //     {
// //         // Play the first SFX clip
// //         audioManager.PlayAudio(0, 0);

// //         // Wait for a frame to allow the audio to play
// //         yield return null;

// //         // Stop the SFX source
// //         audioManager.sfxSource.Stop();

// //         // Assert that the SFX source is not playing
// //         Assert.IsFalse(audioManager.sfxSource.isPlaying);
// //     }

// //     [UnityTest]
// //     public IEnumerator TestStopBackgroundMusic()
// //     {
// //         // Play the first background music clip
// //         audioManager.PlayAudio(1, 0);

// //         // Wait for a frame to allow the audio to play
// //         yield return null;

// //         // Stop the background music source
// //         audioManager.backgroundMusicSource.Stop();

// //         // Assert that the background music source is not playing
// //         Assert.IsFalse(audioManager.backgroundMusicSource.isPlaying);
// //     }
// // }


// using UnityEngine;
// using UnityEngine.TestTools;
// using NUnit.Framework;
// using System.Collections;
// using UnityEngine.SceneManagement;

// public class AudioManagerTests
// {
//     private AudioManager audioManager;

//     [SetUp]
//     public void SetUp()
//     {
//         // Ensure only one instance of AudioManager exists by destroying any previous instance
//         AudioManager existingInstance = GameObject.FindObjectOfType<AudioManager>();
//         if (existingInstance != null) Object.Destroy(existingInstance.gameObject);

//         // Create a new instance of AudioManager
//         GameObject audioManagerGameObject = new GameObject("AudioManager");
//         audioManager = audioManagerGameObject.AddComponent<AudioManager>();
//     }

//     [UnityTest]
//     public IEnumerator SingletonInstanceTest()
//     {
//         yield return null;
//         Assert.AreEqual(audioManager, AudioManager.Instance, "AudioManager instance is not a singleton.");
//     }

//     [UnityTest]
//     public IEnumerator AudioSourcesInitializationTest()
//     {
//         yield return null;

//         Assert.IsNotNull(audioManager.sfxSource, "Sound effects AudioSource is not assigned.");
//         Assert.IsNotNull(audioManager.backgroundMusicSource, "Background music AudioSource is not assigned.");
//         Assert.IsTrue(audioManager.sfxClips.Count > 0, "Sound effects clips list is empty.");
//         Assert.IsTrue(audioManager.audioClips.Count > 0, "Background music clips list is empty.");
//     }

//     [UnityTest]
//     public IEnumerator AudioPlaybackTest()
//     {
//         yield return null;

//         audioManager.sfxSource.clip = audioManager.sfxClips[0];
//         audioManager.sfxSource.Play();
//         yield return new WaitForSeconds(0.1f);
//         Assert.IsTrue(audioManager.sfxSource.isPlaying, "Sound effects source did not play audio.");

//         audioManager.backgroundMusicSource.clip = audioManager.audioClips[0];
//         audioManager.backgroundMusicSource.Play();
//         yield return new WaitForSeconds(0.1f);
//         Assert.IsTrue(audioManager.backgroundMusicSource.isPlaying, "Background music source did not play audio.");
//     }

//     [UnityTest]
//     public IEnumerator VolumeControlTest()
//     {
//         yield return null;

//         audioManager.sfxSource.volume = 0.5f;
//         Assert.AreEqual(0.5f, audioManager.sfxSource.volume, 0.01f, "Sound effects volume did not set correctly.");

//         audioManager.backgroundMusicSource.volume = 0.3f;
//         Assert.AreEqual(0.3f, audioManager.backgroundMusicSource.volume, 0.01f, "Background music volume did not set correctly.");
//     }

//     [UnityTest]
//     public IEnumerator PauseResumeTest()
//     {
//         yield return null;

//         audioManager.backgroundMusicSource.clip = audioManager.audioClips[0];
//         audioManager.backgroundMusicSource.Play();
//         yield return new WaitForSeconds(0.1f);

//         audioManager.backgroundMusicSource.Pause();
//         yield return new WaitForSeconds(0.1f);
//         Assert.IsFalse(audioManager.backgroundMusicSource.isPlaying, "Audio did not pause correctly.");

//         audioManager.backgroundMusicSource.UnPause();
//         yield return new WaitForSeconds(0.1f);
//         Assert.IsTrue(audioManager.backgroundMusicSource.isPlaying, "Audio did not resume correctly.");
//     }

//     [UnityTest]
//     public IEnumerator SceneTransitionBehaviorTest()
//     {
//         yield return null;

//         audioManager.backgroundMusicSource.clip = audioManager.audioClips[0];
//         audioManager.backgroundMusicSource.Play();
//         Assert.IsTrue(audioManager.backgroundMusicSource.isPlaying, "Background music did not start playing.");

//         yield return SceneManager.LoadSceneAsync("AnotherScene"); // Change to an actual scene name for testing
//         yield return new WaitForSeconds(0.1f);

//         Assert.AreEqual(audioManager, AudioManager.Instance, "AudioManager did not persist across scenes.");
//         Assert.IsTrue(audioManager.backgroundMusicSource.isPlaying, "Background music did not continue playing after scene transition.");
//     }
// }
