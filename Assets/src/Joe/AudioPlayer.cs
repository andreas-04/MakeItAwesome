using UnityEngine;

using System.Collections.Generic;

// TODO: Do i need to make this a private class to fit in wiht the private data class requirement?
public class AudioPlayer
{
    [Header("AudioManager Source")]
    public AudioSource musicSource; // AudioSource for background music

    [Header("Background Music")]
    public AudioClip backgroundMusic;

    [Header("SFX Audio Source")]
    public AudioSource sfxSource;

    [Header("Sound Effects")]
    public List<AudioClip> sfxClips; // Array to hold different sound effect clips

    // remove virtual to play a random piece of audio
    // TODO: Make sure that we have the correct public or private attributes here!!!!
    public virtual void Play()
    {
        // rotate to clip and play
        Debug.Log("Play something random");
    }

    private void IncreaseVolume()
    {
        musicSource.volume += 0.1f;
    }

    public class BackgroundAudio : AudioPlayer
    {
        public override void Play()
        {
            // rotate to clip and play
            Debug.Log("Loop");
        }
    }

    public class SFXAudio : AudioPlayer
    {
        public override void Play()
        {
            // rotate to clip and play
            Debug.Log("Playing once");
        }
    }

}

// possibly look up video on how to make monobehavior single for audiomanager 

// stand alone class audio clips (subclass background sfx)
// audio clips uses override in child class and virtual in parent class 
// dynamic bind to audiomanager 
// audio manager being singleton 

// make this singleton too? 
// two new classes (audio player and background audio player (subclass of audio player))
// both have virtual play (parent) and override play (child) (( dynamic binding ))

// audio manager has a collection of audio player

// facade and private class





// audio player, background audio, sfx audio 
// audio player is parent and is an interface for the background audio and sfx audio 
// dynamic binding by making play() virtual

// facade because play() in parent is a common interface for the child classes

// since tying this into the audio manager, it counts as private data class 

// audio manager is facade for audio player 

// background audio class play() will loop the audio clip
// sfx play() will just play one time
// removing the virtual in parent class will just play a random audio clip for the requirement of oral exam


// How do we dynamically bind the play classes to the audiomanger? 


// since tying this into the audio manager, it counts as private data class 

// audio manager is facade for audio player 

// background audio class play() will loop the audio clip
// sfx play() will just play one time
// removing the virtual in parent class will just play a random audio clip for the requirement of oral exam


// How do we dynamically bind the play classes to the audiomanger? 

