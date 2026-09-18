# Slime Dungeon

A fast-paced 2D top-down action survival game built in **Unity 6 (Universal Render Pipeline 2D)**. Players navigate a dungeon arena, fending off an exponentially multiplying swarm of slimes using fireball magic before the arena is completely overwhelmed!

[![Watch Showcase Playlist](https://img.shields.io/badge/YouTube-Showcase%20Playlist-red?style=for-the-badge&logo=youtube)](https://www.youtube.com/playlist?list=PLM3kAW0F-aP0)
[![Unity Version](https://img.shields.io/badge/Unity-6%20(6000.0+)-black?style=for-the-badge&logo=unity)](https://unity.com/)
[![Render Pipeline](https://img.shields.io/badge/Render%20Pipeline-URP%202D-blue?style=for-the-badge)](https://unity.com/srp/universal-render-pipeline)
[![Input System](https://img.shields.io/badge/Input%20System-New%20Input%20System-orange?style=for-the-badge)](https://docs.unity3d.com/Packages/com.unity.inputsystem@latest)

---

## Project Showcase and Dev Log

Watch the gameplay demonstration and development showcase on YouTube:

▶️ **[Slime Dungeon Dev & Gameplay Showcase Playlist](https://www.youtube.com/playlist?list=PLM3kAW0F-aP0)**

---

## How It Works
The core loop is simple: **kill them before they divide.**
* **The Timer Above Their Heads:** Every slime has an 8-second countdown floating above it. When that timer reaches zero, the slime splits into two.
* **How to Win:** Wipe out every last slime after surviving the initial 10-second.
* **How to Lose:** 
  * You run out of health.
  * The dungeon gets completely overrun by **64 slimes**.
---
## Features
* **Mouse-Aim Combat:** Aim freely with your mouse while moving in 8 directions.
* **Fireball Ammo System:** You have 3 fireball charges that recharge every 0.75 seconds. You can burst down an enemy quickly, but if you spam and miss, you’ll be caught reloading.
* **Slime AI:** Slimes don't just sit there—they target you and lunge with an impulse jump every 4 seconds. Getting hit deals damage.
* **Full Game Flow:** 
  * Main Menu with an objective/how-to-play screen.
  * In-game HUD showing health, ammo, reload timer, and your survival time.
  * Victory and Game Over screens with final stats and restart options.
---
## Controls
| Action | Input |
| :--- | :--- |
| **Move** | `W`, `A`, `S`, `D` or Arrow Keys |
| **Aim** | Mouse Cursor |
| **Shoot Fireball** | Left Mouse Click |
| **Menu Buttons** | Mouse Click |
---
## Note
This game is still in the middle of refactoring (after quick prototyping)
