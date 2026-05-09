# U004_IO_Robot_Platform_2D

[English](README.en.md) | [Español](README.md)

## Resumen

**IO Robot Platform 2D** es un prototipo base jugable de plataformas 2D desarrollado en Unity con C#. El jugador controla un robot humanoide en vista lateral, avanzando por una fase con plataformas, trampas, pinchos, enemigos, puertas elevadizas, objetos interactuables y plataformas móviles.

La mecánica principal del proyecto es el cambio de forma del personaje entre dos modos: un modo de combate, representado visualmente en amarillo, que permite disparar proyectiles; y un modo de movilidad, representado en azul, que ofrece más velocidad de movimiento y doble salto. El objetivo es llegar al final del nivel antes de quedarse sin tiempo o sin vidas.

## Tecnologías

- Unity
- C#
- Sistema de físicas 2D de Unity
- Collider2D / Rigidbody2D
- Tilemap
- Animator
- Particle System
- UI básica
- AudioSource
- Sistema de vidas
- Sistema de puntuación
- Sistema de niveles
- Sistema de contrarreloj
- Git LFS
- GitHub Releases

## Características principales

- Gameplay de plataformas 2D con vista lateral.
- Robot humanoide controlado por el jugador.
- Movimiento horizontal.
- Salto y doble salto.
- Caída y gravedad mediante físicas 2D.
- Detección de suelo.
- Plataformas y plataformas móviles.
- Obstáculos, trampas y pinchos.
- Enemigos derrotables.
- Puertas elevadizas accionables con objetos interactuables.
- Cambio entre modo combate y modo movilidad.
- Modo combate con disparo de proyectiles.
- Modo movilidad con mayor velocidad y doble salto.
- Feedback visual por modo: amarillo para combate y azul para movilidad.
- Sistema de límite de balas.
- Recarga de balas por tiempo.
- Sistema de contrarreloj.
- Sistema de vidas.
- Muerte y reinicio.
- Sistema de puntuación.
- Sistema de victoria al llegar al final del nivel.
- Sistema de derrota por tiempo o vidas.
- Menú principal.
- Sistema de pausa.
- Partículas, sonido y música.
- Build jugable para Windows.

## Visuales

> Pendiente de añadir capturas e imágenes finales.

Nombres previstos para el pack visual:

- `iorobot-logo.png`
- `iorobot-cover.png`
- `iorobot-banner.png`
- `iorobot-thumbnail-01-mode-switching.png`
- `iorobot-thumbnail-02-platforming.png`
- `iorobot-thumbnail-03-door-button-puzzle.png`
- `iorobot-thumbnail-04-combat-mode.png`

## Arquitectura

La lógica principal se divide en:

- `BulletControl` — control de proyectiles, límite de balas y disparo.
- `ButtonDoorControl` — interacción con botones y puertas elevadizas.
- `CameraControl` — seguimiento y control de cámara.
- `DestructibleItem` — objetos destructibles.
- `EndLevelControl` — detección de final de nivel y condición de victoria.
- `EnemyControl` — comportamiento de enemigos.
- `GrabbedItemControl` — objetos interactuables o recogibles.
- `LevelManager` — control general de nivel.
- `MenuController` — navegación por menús.
- `MobilePlatform` — comportamiento de plataformas móviles.
- `Parallax` — efecto visual de profundidad en escenario.
- `PlayerModeController` — cambio entre modo combate y modo movilidad.
- `PlayerMovement` — movimiento, salto y físicas del jugador.
- `ScoreController` — puntuación.
- `TimerControl` — contrarreloj y condición de derrota por tiempo.

## Código recomendado para revisar

- [`Project/Assets/Scripts/TimerControl.cs`](./Project/Assets/Scripts/TimerControl.cs)
- [`Project/Assets/Scripts/PlayerModeController.cs`](./Project/Assets/Scripts/PlayerModeController.cs)
- [`Project/Assets/Scripts/BulletControl.cs`](./Project/Assets/Scripts/BulletControl.cs)
- [`Project/Assets/Scripts/ButtonDoorControl.cs`](./Project/Assets/Scripts/ButtonDoorControl.cs)

## Build

La build está disponible en GitHub Releases.

[Descargar build U004-v1.0.0](https://github.com/BLRochaGonzalez93/U004_IO_Robot_Platform_2D/releases/tag/U004-v1.0.0)

## Estado

**Prototipo base jugable.**

El proyecto incluye una fase funcional con movimiento, salto, doble salto, cambio de modo, disparo, límite y recarga de balas, enemigos, trampas, plataformas móviles, puertas accionables, contrarreloj, vidas, puntuación, victoria, derrota, menú principal, pausa, partículas, sonido y música.

Pendiente de posibles mejoras:

- Añadir más niveles.
- Añadir más tipos de enemigos.
- Añadir checkpoints.
- Añadir más objetos interactuables.
- Añadir más habilidades para cada forma.
- Ajustar balance del límite y recarga de balas.
- Ajustar balance del contrarreloj.
- Añadir guardado de progreso.
- Añadir pantalla de victoria más completa.
- Añadir pantalla de derrota más completa.

## Aprendizajes

Este proyecto me permitió trabajar movimiento y salto 2D con `Rigidbody2D`, detección de suelo y control de personaje en un entorno de plataformas.

También me ayudó a diseñar un personaje con dos modos de gameplay claramente diferenciados, tanto a nivel mecánico como visual: combate y movilidad.

Además, el proyecto me permitió practicar gestión de proyectiles con límite y recarga por tiempo, implementación de contrarreloj, vidas, victoria y derrota, e interacción con puertas, botones, plataformas móviles y objetos destructibles.

Por último, el proyecto sirvió para organizar un prototipo de plataformas con múltiples sistemas conectados, separando responsabilidades entre jugador, modos, disparo, nivel, UI, tiempo y feedback.
