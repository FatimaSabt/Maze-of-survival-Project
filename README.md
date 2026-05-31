# Maze of Survival

Maze of Survival is a first-person 3D Puzzle-Survival adventure game designed for PC. Players are challenged to escape a series of deadly labyrinths by navigating complex corridors, avoiding lethal traps, and locating a hidden key that unlocks the exit door. The game features a high-stakes gameplay experience where a single mistake can result in defeat, requiring players to balance observation, timing, and strategic movement.

## 🎮 Core Features

* **Progressive Difficulty**: Navigate through 5 distinct handcrafted levels, each increasing in size, complexity, and challenge.
  
* **Dual Gameplay Modes**:
  * **Main Survival Mode**: A puzzle-focused escape experience relying on timing and precision.
  * **VS AI Mode**: A high-pressure pursuit mode where an AI-controlled hunter actively chases the player through the maze. In the final level, retrieving the key deactivates the traps but immediately triggers a relentless chase to the exit.
    
* **Deadly Hazards**: Survive a variety of environmental traps including:
  * Poison Floor Tiles
  * Fire Jets
  * Floor Spikes
  * Arrow Shooters
  * Swinging Blades
 
* **Risk vs. Reward System**: Explore optional paths throughout the maze to collect hidden coins and increase your final score.

* **Level Progression System**: Players must successfully complete all 5 levels to win the game. Progress is not saved between play sessions. Returning to the Main Menu resets progression back to Level 1. However, if a player dies during a level, they may immediately replay that same level without restarting the entire game.
---

## ⌨️ Controls

The game requires a keyboard and mouse to play.

| Action | Input |
| :--- | :--- |
| **Move Forward** | `W` / `Up Arrow` |
| **Move Backward** | `S` / `Down Arrow` |
| **Move Left** | `A` / `Left Arrow` |
| **Move Right** | `D` / `Right Arrow` |
| **Jump** | `Spacebar` |
| **Look Around** | `Mouse` / `Trackpad` |
| **Pause Game** | `ESC` / `P` |

*Coins and keys are collected automatically when the player walks through them.*

---

## 🛠️ Technical Stack

* **Game Engine**: Unity
* **Programming Language**: C#
* **AI Pathfinding**: Unity NavMesh System
* **UI System**: TextMeshPro (TMP) for menus and game statistics
* **Architecture**: Singleton-based managers (Scene Controller and UI Manager) combined with a modular Prefab workflow for level construction and gameplay systems

---

## 👥 Development Team

This project was collaboratively developed by:
* **Fatima Sabt**
* **Fatima Alshabbaq**
* **Fatema Almajed**
* **Noor Mohammed**
* **Reem Janahi**
