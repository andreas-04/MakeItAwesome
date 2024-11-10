# Worm Manager Prefab

★★★★★ (532 reviews)  
**Author**: Andreas
**Price**: $59.99  
**Version**: 1.0  
**Compatibility**: Unity 2022.3.42f1 or later  

## Description
The Worm Manager prefab is an advanced asset designed to give your game a unique, dynamic worm-based character. This prefab controls the worm's growth and movement, allowing the player to control a head segment that drags a series of body parts behind it in a smooth, snakelike manner. 

## Features
- **Player-Controlled Movement**: Allows players to navigate the worm's head with precision while the body segments follow naturally.
- **Realistic Segment Tracking**: Each body part follows the path of the preceding segment, producing a fluid motion.
- **Marker System**: Integrated `MarkerManager` component for position and rotation tracking, enabling seamless following and rotations.

## Components Included

### 1. MarkerManager
- **Purpose**: Tracks and manages the position and rotation of each worm body segment to allow fluid following mechanics.
- **Primary Methods**:
  - `UpdateMarkerList()`: Adds the current position and rotation to the list for tracking.
  - `ClearMarkerList()`: Clears and resets the marker list to maintain clean tracking data for each new segment.

### 2. WormManager
- **Purpose**: Manages the worm's segments, controls growth, and handles player movement input.
- **Primary Methods**:
  - `CreateBodyParts()`: Instantiates and configures worm body segments and updates the `MarkerManager`.
  - `WormMovement()`: Handles player-controlled movement for the worm's head while allowing the other segments to follow the path naturally.

## Requirements
Unity 2022.3.42f1 or later
