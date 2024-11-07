# AudioManager Prefab

## Overview
This prefab is designed to manage audio playback in a Unity project. It contains an `AudioManager` class to control two main audio sources: one for background music and one for sound effects (SFX). The `AudioPlayer` class manages individual audio source playback, with specialized classes for background and SFX audio.

## Components
- **AudioManager**: The central manager for audio control, responsible for:
  - Singleton instance management to ensure a single audio manager across scenes.
  - Managing two main `AudioSource` components:
    - `backgroundMusicSource`: Handles background music playback.
    - `sfxSource`: Manages sound effect playback.
  - Providing methods to play, stop, and manage audio sources.

- **AudioPlayer**: Handles playback for individual audio sources.
  - Contains methods to play audio and includes safeguards for missing audio clips or sources.
  - Specialized subclasses:
    - `BackgroundAudio`: Plays looping background audio.
    - `SFXAudio`: Plays one-shot sound effects.

## Setup Instructions
1. Add the `AudioManager` prefab to the scene.
2. Set up references for the `backgroundMusicSource` and `sfxSource` in the `AudioManager` component.
3. Ensure audio clips are attached to the appropriate `AudioSource` components in the Unity Inspector.

## Usage
- Use `AudioManager.Instance` to access the audio manager instance from any script.
- Call `PlayBackgroundMusic()` and `PlaySFX()` to control background music and sound effects, respectively.

## Code Reference

### AudioManager.cs
Manages background music and sound effects. Ensures only one instance exists across scenes.
