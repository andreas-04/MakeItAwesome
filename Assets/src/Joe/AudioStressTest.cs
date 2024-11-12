// using UnityEngine;
// using System.Collections;
// using System.Collections.Generic;

// public class AudioStressTest : MonoBehaviour
// {
//     public long playCount = 100000000000;              // Number of attempts
//     public float delayBetweenClips = 0.0000000000005f; // Delay between attempts
//     public int maxFailures = 10;                        // Number of allowed failures before test fails
//     public float minFrameRate = 12f;                   // Minimum acceptable frame rate
//     public int maxAudioSources = 1000;                   // Maximum number of audio sources allowed to play simultaneously

//     public int failedFrameRate;
//     public List<AudioClip> testClips;                  // List of audio clips to use in the test

//     private int failureCount = 0;
//     private List<AudioSource> audioSources = new List<AudioSource>();

//     void Start()
//     {
//         StartCoroutine(PlayAudioStressTest());
//     }

//     IEnumerator PlayAudioStressTest()
//     {
//         for (int i = 0; i < playCount; i++)
//         {
//             try
//             {
//                 // Create a new AudioSource component
//                 AudioSource newAudioSource = gameObject.AddComponent<AudioSource>();
//                 audioSources.Add(newAudioSource);

//                 // Select a random clip from the list
//                 int clipIndex = Random.Range(0, testClips.Count);
//                 newAudioSource.clip = testClips[clipIndex];

//                 // Play the audio clip
//                 newAudioSource.Play();

//                 // Check frame rate
//                 if (1.0f / Time.deltaTime < minFrameRate)
//                 {
//                     failedFrameRate = (int)(1.0f / Time.deltaTime);
//                     Debug.LogError("Audio stress test failed due to low frame rate at: " + failedFrameRate + "Play count: " + i);
//                     yield break;
//                 }
//             }
//             catch (System.Exception e)
//             {
//                 Debug.LogError($"Audio play failed: {e.Message}");
//                 failureCount++;

//                 // Fail the test if failures exceed threshold
//                 if (failureCount >= maxFailures)
//                 {
//                     Debug.LogError("Audio stress test failed due to excessive errors.");
//                     yield break;
//                 }
//             }

//             // Wait briefly before next attempt
//             yield return new WaitForSeconds(delayBetweenClips);

//             // Clean up finished audio sources
//             audioSources.RemoveAll(source => !source.isPlaying);
//         }

//         Debug.Log("Audio stress test completed successfully.");
//     }
// }