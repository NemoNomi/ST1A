# Drees & Sommer STA1 Project

## Introduction
This project is developed for Drees & Sommer, a company specializing in consulting for urban planning. The goal of this project is to create a gamified application that showcases the benefits of Drees & Sommer's solutions for city administrations. The application allows users to manage the construction of a city while dealing with stressors, demonstrating how Drees & Sommer can help manage these challenges effectively.

## Game Idea
The game revolves around building a city. Users will face various stressors and must manage them. Solutions provided by Drees & Sommer will be depicted through different NPCs (Non-Player Characters) that can be called upon to solve specific issues. The user interacts with the game by clicking buttons to spawn NPCs who then move to designated target positions to perform their tasks.

## Unity Version
We are using Unity version `2022.3.20f1` for this project.

## Project Structure

<details>
<summary><strong>Scripts Overview</strong></summary>

### IMovementController.cs
- **Purpose:** Defines an interface for movement controllers, providing a method to move an object to a specified target position.
- **Details:** Any class implementing this interface must provide an implementation for the `MoveTo(Vector3 targetPosition)` method.

### NavMeshMovementController.cs
- **Purpose:** Implements the actual movement logic for NPCs using Unity's `NavMeshAgent`.
- **Details:** 
  - Initializes the `NavMeshAgent` component.
  - Implements the `MoveTo(Vector3 targetPosition)` method to set the destination of the `NavMeshAgent`.

### NPCMovementController.cs
- **Purpose:** Acts as an intermediary that delegates the movement commands to an implementation of the `IMovementController` interface.
- **Details:**
  - Initializes the movement controller (which is an implementation of `IMovementController`) in the `Awake` method.
  - Uses the `MoveTo(Vector3 targetPosition)` method to delegate movement commands to the actual movement controller, which in this case could be `NavMeshMovementController`.

### NPCSpawnerController.cs
- **Purpose:** Handles spawning and moving NPCs based on specified data.
- **Details:**
  - Contains a nested `NPCData` struct to hold data for spawning and moving NPCs.
  - Manages an array of `NPCData` for different NPC types.
  - Provides a method to spawn the NPC at the given spawn point and move it to the target position.
  - Uses a coroutine to manage the timing of the spawn and move actions.
  - Prevents spawning of duplicate NPCs by checking against an existing list of active NPCs.
  - Activates a UI panel to display error messages when duplicate NPCs are attempted to be spawned.

### NPCInstancesManager.cs
- **Purpose:** Manages active NPC instances in the scene to prevent duplicates.
- **Details:**
  - Maintains a list of active NPCs.
  - Provides methods to register, unregister, and check for NPC instances in the scene.

### UIManager.cs
- **Purpose:** Manages UI elements related to NPC spawning errors.
- **Details:**
  - Activates a message panel to display error messages.
  - Uses a coroutine to clear the message after a delay.

</details>

<details>
<summary><strong>Architecture and Design Principles</strong></summary>

### Game Flow
1. **Spawning NPCs:** The `NPCSpawnerController` spawns NPCs at specified spawn points and moves them to their target positions.
2. **Moving NPCs:** The `NPCMovementController` delegates movement commands to the `IMovementController` implementation.
3. **Coordination:** The `NPCSpawnerController` manages the process of spawning and moving NPCs using a coroutine for timed movements.
4. **Error Handling:** The `NPCSpawnerController` checks if an NPC is already in the scene using the `NPCInstancesManager` and activates the `UIManager` panel for error messages if necessary.

### Class Relationships
- `NPCSpawnerController` relies on the `NPCMovementController` to handle NPC movement.
- `NavMeshMovementController` implements the movement logic and is used by `NPCMovementController`.
- `NPCInstancesManager` manages the active NPCs to prevent duplicates.
- `UIManager` handles the display of error messages when duplicate NPCs are attempted to be spawned.

### Usage Instructions
- **Spawning and Moving NPCs:**
  - Attach the `NPCSpawnerController` to a GameObject.
  - Configure the `NPCData` array in the `NPCSpawnerController` with NPC prefabs, spawn points, and target points.
  - Call the `SpawnNPC(index)` method from the `NPCSpawnerController` to spawn and move an NPC based on the index.

</details>
