# Pause Menu Prefab for Unity

## Overview
The Pause Menu Prefab is a versatile and easy-to-use solution for adding a pause feature to your Unity game. It allows players to pause the game, resume gameplay, view game controls, and exit the game. The menu appears as a UI panel and provides a user-friendly interface for managing game flow.

## Features
- **Pause Button**: Pauses the game by stopping the in-game time, allowing players to take a break without missing any action.
- **Controls Button**: Opens a panel that displays game controls, helping players understand how to interact with your game.
- **Resume Button**: Allows players to resume gameplay after pausing.
- **Exit Button**: Exits the game, giving players the option to leave at any point.
- **UI Panel Display**: The pause menu appears as a UI panel that overlays the current gameplay, ensuring players do not miss the context of where they paused.

## How to Use
1. **Add the Prefab**: Drag the Pause Menu Prefab into your scene.
2. **Assign Buttons**: The prefab comes with buttons for "Resume", "Controls", and "Exit". Make sure the buttons are properly connected to the `PauseMenuManager` script, which handles button interactions.
3. **Pause Game**: The pause menu uses `Time.timeScale = 0` to pause the game. This effectively freezes all game actions, including animations and physics.

## Button Functionality
- **Resume**: When the resume button is clicked, the game resumes (`Time.timeScale = 1`), and the pause menu UI is hidden.
- **Controls**: Opens a panel displaying the game controls, providing users with clear instructions on how to play the game.
- **Exit**: Calls `Application.Quit()` to close the game. Note that in the Unity Editor, this will not fully close the application but will display a log message instead.

## Customization
- **UI Design**: The prefab includes a default UI panel, which can be customized to match your game's theme. You can modify the panel's colors, fonts, and button styles as desired.
- **Control Panel Content**: Customize the controls panel to include the relevant information for your game.

## Script Overview
The `PauseMenuManager` script manages the functionality of the pause menu. It includes methods for pausing, resuming, opening the controls panel, and quitting the game. Ensure the appropriate UI elements are assigned in the script via the Inspector.

## Important Notes
- **Testing in Editor**: The exit button will not close the game in the Unity Editor. Instead, a log message will be displayed (`Debug.Log("Game exited")`). The actual quit functionality will only work in a built version of the game.
- **Time Scale**: The pause functionality works by setting `Time.timeScale` to 0. Ensure there are no unintended side effects in your game when `Time.timeScale` is altered.

## Example Usage
1. Press the **Pause** button or the assigned key to open the pause menu.
2. Use the **Resume** button to continue playing.
3. Click on **Controls** to view the game instructions.
4. Press **Exit** to leave the game.

## Dependencies
- **Unity Version**: This prefab has been tested with Unity 2021.3 and above.
- **UI Elements**: Make sure you have the Unity UI package installed and configured properly.

## Future Improvements
- **Audio Pause**: Optionally add a feature to pause background music when the game is paused.
- **Save Game State**: Implement functionality to save the game state when the pause menu is activated.
