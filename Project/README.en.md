[English](README.en.md) | [Español](README.md)

# U004_IO_Robot_Platform_2D

## Summary

Playable base 2D platformer prototype developed in Unity with C#. The player controls a humanoid robot in side view and must complete a level with platforms, traps, enemies, lift doors and interactive objects.

The main feature is switching between two forms: combat mode, colored yellow, capable of shooting projectiles; and mobility mode, colored blue, with higher speed and double jump. The player wins by reaching the end of the level and loses by running out of time or lives.

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

- Side-view 2D platformer.
- Humanoid robot as the playable character.
- Horizontal movement.
- Jump and double jump.
- Falling, gravity and ground detection.
- Platforms and moving platforms.
- Obstacles, traps and spikes.
- Defeatable enemies.
- Lift doors activated through interactive objects.
- Combat mode with projectiles.
- Mobility mode with higher speed and double jump.
- Visual form switching: yellow for combat and blue for mobility.
- Bullet limit.
- Time-based bullet recharge.
- Countdown timer system.
- Lives system.
- Death and restart.
- Scoring system.
- Level system.
- Victory by reaching the end.
- Defeat by running out of time or lives.
- Main menu.
- Pause.
- Particles.
- Sound and music.
- Playable Windows build.

## Screenshots

> Final screenshots pending.

Planned path:

![Gameplay](../Media/screenshots/gameplay-01.png)

## Architecture

The main logic is divided into:

- `BulletControl` — shooting, projectiles, limit and recharge.
- `ButtonDoorControl` — buttons, lift doors and interaction.
- `CameraControl` — camera control.
- `DestructibleItem` — destructible elements.
- `EndLevelControl` — level end and victory.
- `EnemyControl` — enemies.
- `GrabbedItemControl` — interactive objects.
- `LevelManager` — level control.
- `MenuController` — menus.
- `MobilePlatform` — moving platforms.
- `Parallax` — visual depth effect.
- `PlayerModeController` — switching between combat and mobility modes.
- `PlayerMovement` — movement, jump and physics.
- `ScoreController` — score.
- `TimerControl` — timer and time-based defeat.

More information:

[`Docs/Architecture.md`](./Docs/Architecture.md)

## Recommended code to review

[`PRJ_Plataforma2D/Assets/Scripts/TimerControl.cs`](./PRJ_Plataforma2D/Assets/Scripts/TimerControl.cs)
[`PRJ_Plataforma2D/Assets/Scripts/PlayerModeController.cs`](./PRJ_Plataforma2D/Assets/Scripts/PlayerModeController.cs)
[`PRJ_Plataforma2D/Assets/Scripts/BulletControl.cs`](./PRJ_Plataforma2D/Assets/Scripts/BulletControl.cs)
[`PRJ_Plataforma2D/Assets/Scripts/ButtonDoorControl.cs`](./PRJ_Plataforma2D/Assets/Scripts/ButtonDoorControl.cs)

## Build

The build is available through GitHub Releases.

[`Releases/Download.en.md`](../Releases/Download.en.md)

[Download build U004-v1.0.0](https://github.com/BLRochaGonzalez93/U004_IO_Robot_Platform_2D/releases/tag/U004-v1.0.0)

## Status

**Playable base prototype.**

The project contains one functional level with player, enemies, obstacles, moving platforms, activatable doors, mode switching, projectiles, bullet limit, time-based recharge, countdown timer, lives, score, victory, defeat, menu, pause, particles, sound and music.

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

This project allowed me to work on 2D movement and jumping with `Rigidbody2D`, including ground detection, gravity, platforms and character control.

It also helped me design a character with two gameplay modes, separating responsibilities between mobility, combat and visual feedback.

In addition, I practiced projectile management with bullet limits and time-based recharge, countdown timer, lives, victory, defeat and interaction with doors, buttons, moving platforms and destructible objects.

The project also helped me organize a platformer prototype with multiple connected systems, maintaining an architecture split between player, level, enemies, UI, time, score and global logic.
