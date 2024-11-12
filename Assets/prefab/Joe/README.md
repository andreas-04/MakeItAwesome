# AudioManager Prefab

## Overview
This prefab is designed to manage audio playback in a Unity project. It contains an `AudioManager` class to control two main audio sources: one for background music and one for sound effects (SFX). The `AudioPlayer` class manages individual audio source playback, with specialized classes for background and SFX audio.

## Components
- **AudioManager**: The central manager for audio control, responsible for:
  - User for the facade pattern found in audioPlayer. 
  - User in private data class pattern in the AudioPlayer
  - Managing two main `AudioSource` components:
    - `backgroundMusicSource`: Handles background music playback.
    - `sfxSource`: Manages sound effect playback.
  - Providing methods to play and manage audio.

- **AudioPlayer**: Handles playing aduio on the system level. 
  - Contains methods to play audio at the system level. 
  - Implements a facade to allow audioManager to easily play audio.
  - Dynamic binding possibilities with virtual and overridden methods. 
  - Can be utilized as a private data class due to only being able to set audio from class functions. 
  - Specialized subclasses:
    - `BackgroundAudio`: Plays looping background audio.
    - `SFXAudio`: Plays one-shot sound effects.

- **Audio**: This is the gameObject that holds the entire prefab including audioSources.
  - Contains the link and port to all audiosources (within prefab) and audio clips.

## Setup Instructions
1. Add the `AudioManager` prefab to the scene.
2. Within MakeItAwesome REPO you don't need to link audio clips but in other repositories you may need to. 

## Usage
- Use `AudioManager.Instance` to access the audio manager instance from any script.
- Call `Play(int, int)` and `PlaySFX(int)` to control background music and sound effects, respectively.

## Requirements
- Unity Editor 2022.3.47f1
