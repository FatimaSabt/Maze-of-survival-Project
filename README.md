# Maze of Survival

Maze of Survival is a first-person 3D Puzzle-Survival adventure game designed for PC. Players are thrust into a series of deadly labyrinths and must navigate complex corridors, avoid lethal traps, and find a hidden key to unlock the exit door. The game features a high-stakes "single-life" system where any mistake leads to instant defeat, forcing players to balance careful observation with strategic movement.

## 🎮 Core Features

* **Progressive Difficulty**: Navigate through 5 distinct, handcrafted levels that increase in complexity and hazard density.
* **Dual Gameplay Modes**:
  * **Main Survival Mode**: A puzzle-focused escape experience relying on timing and precision.
  * **VS AI Mode**: A high-pressure pursuit mode where an AI-controlled hunter actively chases the player through the maze. In the final level, retrieving the key deactivates the traps but immediately triggers a relentless chase to the exit.
* **Deadly Hazards**: Survive a variety of environmental traps including Poison Floor Tiles, Fire Jets, Wall Spikes, Swinging Blades, and Arrow Shooters.
* **Risk vs. Reward System**: Explore alternate paths to collect hidden coins to maximize your final score on the leaderboard.

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

*Note: Coins and keys are automatically collected by walking through them.*

---

## 🛠️ Technical Stack

* [cite_start]**Game Engine**: Unity
* [cite_start]**Programming Language**: C#
* [cite_start]**AI Pathfinding**: Unity NavMesh System
* [cite_start]**UI System**: TextMeshPro (TMP) for global stat tracking and menus
* [cite_start]**Architecture**: heavily utilizes the Singleton pattern for the Scene Controller and UI Manager, alongside a modular Prefab workflow for level generation.

---

## 👥 Development Team

This project was collaboratively developed by:
* **Fatima Sabt**
* **Fatima Alshabbaq**
* **Fatema Almajed**
* **Noor Mohammed**
* **Reem Janahi**
