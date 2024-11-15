# Enemy Prefab
Author: Caden Sampsel

## Overview
This prefab gets a prebuilt enemy object into your game. This object uses the a* pathfinding project to pathfind towards anything with the player tag on it. It also comes with a healthbar and will take damage from the player object on collision.

## Components
- The first component is the enemy spawning script. This allows you to spawn as many of the enemies as you want anywhere on your map. You just need to change the values in the Instantiante function and you can place your enemies anywhere.
- You also have the enemy script that would take damage from the player. This can be customized to change the amount of health on the enemy and how much damage is taken from each collision.
- There is also an enemy attack script that you can customize a ranged attack to shoot at your player if you wanted to.

## Setup Instructions
1. Make sure that you are running Unity Editor 2022.3.47f1 or later. Not doing so could cause some issues while using the prefab.
2. Just add the enemy prefab to your scene inside of Unity.
3. Customize any of the values that you want to and make sure that the enemy and player have the correct tags on them.


