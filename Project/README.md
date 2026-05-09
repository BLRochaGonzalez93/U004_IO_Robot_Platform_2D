# U004_IO_Robot_Platform_2D

[English](README.en.md) | [Español](README.md)

## Resumen

Prototipo base jugable de plataformas 2D desarrollado en Unity con C#. El jugador controla un robot humanoide en vista lateral y debe superar una fase con plataformas, trampas, enemigos, puertas elevadizas y objetos interactuables.

La característica principal es el cambio entre dos formas: modo combate, de color amarillo, capaz de disparar proyectiles; y modo movilidad, de color azul, con mayor velocidad y doble salto. El jugador gana al llegar al final del nivel y pierde si se queda sin tiempo o sin vidas.

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

- Plataformas 2D con vista lateral.
- Robot humanoide como personaje jugable.
- Movimiento horizontal.
- Salto y doble salto.
- Caída, gravedad y detección de suelo.
- Plataformas y plataformas móviles.
- Obstáculos, trampas y pinchos.
- Enemigos derrotables.
- Puertas elevadizas accionables mediante objetos interactuables.
- Modo combate con proyectiles.
- Modo movilidad con más velocidad y doble salto.
- Cambio visual de forma: amarillo para combate y azul para movilidad.
- Límite de balas.
- Recarga de balas por tiempo.
- Sistema de contrarreloj.
- Sistema de vidas.
- Muerte y reinicio.
- Sistema de puntuación.
- Sistema de niveles.
- Victoria al llegar al final.
- Derrota por falta de tiempo o vidas.
- Menú principal.
- Pausa.
- Partículas.
- Sonido y música.
- Build jugable para Windows.

## Capturas

> Pendiente de añadir capturas finales.

Ruta prevista:

![Gameplay](../Media/screenshots/gameplay-01.png)

## Arquitectura

La lógica principal se divide en:

- `BulletControl` — disparo, proyectiles, límite y recarga.
- `ButtonDoorControl` — botones, puertas elevadizas e interacción.
- `CameraControl` — control de cámara.
- `DestructibleItem` — elementos destructibles.
- `EndLevelControl` — final de fase y victoria.
- `EnemyControl` — enemigos.
- `GrabbedItemControl` — objetos interactuables.
- `LevelManager` — control del nivel.
- `MenuController` — menús.
- `MobilePlatform` — plataformas móviles.
- `Parallax` — efecto de profundidad visual.
- `PlayerModeController` — cambio entre modo combate y movilidad.
- `PlayerMovement` — movimiento, salto y físicas.
- `ScoreController` — puntuación.
- `TimerControl` — temporizador y derrota por tiempo.

Más información en:

[`Docs/Architecture.md`](./Docs/Architecture.md)

## Código recomendado para revisar

[`PRJ_Plataforma2D/Assets/Scripts/TimerControl.cs`](./PRJ_Plataforma2D/Assets/Scripts/TimerControl.cs)
[`PRJ_Plataforma2D/Assets/Scripts/PlayerModeController.cs`](./PRJ_Plataforma2D/Assets/Scripts/PlayerModeController.cs)
[`PRJ_Plataforma2D/Assets/Scripts/BulletControl.cs`](./PRJ_Plataforma2D/Assets/Scripts/BulletControl.cs)
[`PRJ_Plataforma2D/Assets/Scripts/ButtonDoorControl.cs`](./PRJ_Plataforma2D/Assets/Scripts/ButtonDoorControl.cs)

## Build

La build está disponible en GitHub Releases.

[`Releases/Download.md`](../Releases/Download.md)

[Descargar build U004-v1.0.0](https://github.com/BLRochaGonzalez93/U004_IO_Robot_Platform_2D/releases/tag/U004-v1.0.0)

## Estado

**Prototipo base jugable.**

El proyecto contiene una fase funcional con jugador, enemigos, obstáculos, plataformas móviles, puertas accionables, cambio de modo, proyectiles, límite de balas, recarga por tiempo, contrarreloj, vidas, puntuación, victoria, derrota, menú, pausa, partículas, sonido y música.

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

Este proyecto me permitió trabajar movimiento y salto 2D con `Rigidbody2D`, incluyendo detección de suelo, gravedad, plataformas y control del personaje.

También me sirvió para diseñar un personaje con dos modos de gameplay, separando responsabilidades entre movilidad, combate y feedback visual.

Además, pude practicar gestión de proyectiles con límite y recarga por tiempo, contrarreloj, vidas, victoria, derrota e interacción con puertas, botones, plataformas móviles y objetos destructibles.

El proyecto también me ayudó a organizar un prototipo de plataformas con múltiples sistemas conectados, manteniendo una arquitectura dividida entre jugador, nivel, enemigos, UI, tiempo, puntuación y lógica global.
