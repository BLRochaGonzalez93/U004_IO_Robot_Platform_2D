# U004_IO_Robot_Platform_2D

[English](README.en.md) | [Español](README.md)

## Summary

**IO Robot Platform 2D** is a playable base 2D platformer prototype developed in Unity with C#. The player controls a humanoid robot in a side-view level, progressing through platforms, traps, spikes, enemies, lift doors, interactive objects and moving platforms.

The core mechanic of the project is the character's form switching between two modes: a combat mode, visually represented in yellow, which allows the player to shoot projectiles; and a mobility mode, represented in blue, which provides higher movement speed and double jump. The objective is to reach the end of the level before running out of time or lives.

## Technologies

- Unity
- C#
- Unity 2D physics system
- Collider2D / Rigidbody2D
- Tilemap
- Animator
- Particle System
- Basic UI
- AudioSource
- Lives system
- Scoring system
- Level system
- Countdown timer system
- Git LFS
- GitHub Releases

## Main features

- Side-view 2D platformer gameplay.
- Humanoid robot controlled by the player.
- Horizontal movement.
- Jump and double jump.
- Falling and gravity through 2D physics.
- Ground detection.
- Platforms and moving platforms.
- Obstacles, traps and spikes.
- Defeatable enemies.
- Lift doors activated through interactive objects.
- Switching between combat mode and mobility mode.
- Combat mode with projectile shooting.
- Mobility mode with higher speed and double jump.
- Visual feedback per mode: yellow for combat and blue for mobility.
- Bullet limit system.
- Time-based bullet recharge.
- Countdown timer system.
- Lives system.
- Death and restart.
- Scoring system.
- Victory by reaching the end of the level.
- Defeat by running out of time or lives.
- Main menu.
- Pause system.
- Particles, sound and music.
- Playable Windows build.

## Visuals

> Final screenshots and images pending.

Planned visual pack names:

- `iorobot-logo.png`
- `iorobot-cover.png`
- `iorobot-banner.png`
- `iorobot-thumbnail-01-mode-switching.png`
- `iorobot-thumbnail-02-platforming.png`
- `iorobot-thumbnail-03-door-button-puzzle.png`
- `iorobot-thumbnail-04-combat-mode.png`

## Architecture

The main logic is divided into:

- `BulletControl` — projectile control, bullet limit and shooting.
- `ButtonDoorControl` — button and lift-door interaction.
- `CameraControl` — camera follow and control.
- `DestructibleItem` — destructible objects.
- `EndLevelControl` — end-level detection and victory condition.
- `EnemyControl` — enemy behavior.
- `GrabbedItemControl` — interactive or grabbable objects.
- `LevelManager` — general level control.
- `MenuController` — menu navigation.
- `MobilePlatform` — moving platform behavior.
- `Parallax` — visual depth effect for the environment.
- `PlayerModeController` — switching between combat mode and mobility mode.
- `PlayerMovement` — player movement, jump and physics.
- `ScoreController` — score handling.
- `TimerControl` — countdown timer and time-based defeat condition.

## Recommended code to review

- [`Project/Assets/Scripts/TimerControl.cs`](./Project/Assets/Scripts/TimerControl.cs)
- [`Project/Assets/Scripts/PlayerModeController.cs`](./Project/Assets/Scripts/PlayerModeController.cs)
- [`Project/Assets/Scripts/BulletControl.cs`](./Project/Assets/Scripts/BulletControl.cs)
- [`Project/Assets/Scripts/ButtonDoorControl.cs`](./Project/Assets/Scripts/ButtonDoorControl.cs)

## Build

The build is available through GitHub Releases.

[Download build U004-v1.0.0](https://github.com/BLRochaGonzalez93/U004_IO_Robot_Platform_2D/releases/tag/U004-v1.0.0)

## Status

**Playable base prototype.**

The project includes one functional level with movement, jump, double jump, mode switching, shooting, bullet limit and recharge, enemies, traps, moving platforms, activatable doors, countdown timer, lives, score, victory, defeat, main menu, pause, particles, sound and music.

Possible pending improvements:

- Add more levels.
- Add more enemy types.
- Add checkpoints.
- Add more interactive objects.
- Add more abilities for each form.
- Adjust the balance of the bullet limit and recharge.
- Adjust the balance of the countdown timer.
- Add progress saving.
- Add a more complete victory screen.
- Add a more complete defeat screen.

## Learnings

This project allowed me to work on 2D movement and jumping with `Rigidbody2D`, ground detection and character control in a platforming environment.

It also helped me design a character with two clearly differentiated gameplay modes, both mechanically and visually: combat and mobility.

In addition, the project allowed me to practice projectile management with bullet limits and time-based recharge, countdown timer implementation, lives, victory and defeat, and interaction with doors, buttons, moving platforms and destructible objects.

Finally, the project helped me organize a platformer prototype with multiple connected systems, separating responsibilities between player, modes, shooting, level, UI, time and feedback.
