# Game Design Document

## Title: IUS Marketplace
**Date:** 09.06.2024  
**Iteration No.:** 5.0  

## Summary
An interactive application developed in Unity for Drees & Sommer. The game simulates a marketplace where various stakeholders in urban planning come together to discuss and negotiate the future of city development. The player experiences the complexities of urban planning and the need for integrated solutions.

## Unity Version
We are using Unity version `2022.3.20f1` for this project.

&ensp;

## Table of Contents
1. [Game Overview](#game-overview)
   - [a. Core Concept](#a-core-concept)
   - [b. Unique Selling Points](#b-unique-selling-points)
   - [c. Genre](#c-genre)
   - [d. Target Audience](#d-target-audience)
   - [e. Platforms](#e-platforms)
2. [Story](#story)
   - [a. Plot Summary](#a-plot-summary)
   - [b. Themes and Messages](#b-themes-and-messages)
   - [c. Characters](#c-characters)
3. [Gameplay](#gameplay)
   - [a. Core Gameplay Loop](#a-core-gameplay-loop)
   - [b. Mechanics](#b-mechanics)
   - [c. Controls](#c-controls)
   - [d. Formal Objectives](#d-formal-objectives)
   - [e. Sensory Objectives](#e-sensory-objectives)
   - [f. Failure States](#f-failure-states)
4. [Visual Style](#visual-style)
5. [Further Development Ideas](#further-development-ideas)

&ensp;

## 1. Game Overview

### a. Core Concept
The marketplace is an interactive simulation that immerses players in the complexities of urban planning. Players must balance the needs and interests of different stakeholders to create sustainable and effective city plans.

### b. Unique Selling Points
- **Educational Value**: Highlights the challenges and intricacies of urban planning.
- **Interactive Learning**: Uses gamification to engage users in understanding urban development.
- **Realistic Scenarios**: Based on real-world urban planning principles and issues.

### c. Genre
Simulation, Educational

### d. Target Audience
- (Federal, EU and UN) institutions
- Investors
- Municipal administrations
- Professional associations

### e. Platforms
- Mobile Devices (Tablets, Smartphones)
- Web-based application

&ensp;

## 2. Story

### a. Plot Summary
In a virtual representation of Drees & Sommer's office, the player takes on the role of an urban planner. The core setting is a round table symbolizing equality and collaborative discussion. Players must invite representatives from different sectors (Climate, Finance, Society) to discuss and propose city planning solutions.

### b. Themes and Messages
- **Collaboration**: Emphasizes the importance of integrating diverse perspectives.
- **Sustainability**: Focuses on long-term environmental impact and innovative planning.
- **Complexity of Decision-Making**: Showcases the challenges and trade-offs in urban development.

### c. Characters
| Character                  | Description                                                                 |
|----------------------------|-----------------------------------------------------------------------------|
| **Haris**                  | A Drees & Sommer consultant who assists in resolving conflicts.             |
| **Climate Representative** | Focuses on environmental sustainability and ecological impact.              |
| **Finance Representative** | Concentrates on financial viability and economic growth.                    |
| **Society Representative** | Prioritizes social well-being, community needs, and public interests.       |
| **Drees & Sommer Team**    | A team of experts who provide solutions to balance the factors.             |

&ensp;

## 3. Gameplay

### a. Core Gameplay Loop
1. **Scenario Presentation**: Players start with a scenario at the round table where different urban planning challenges are presented.
2. **Initial Invitation**: Players receive a post-it note from the boss instructing them to invite representatives of Climate, Finance, and Society to the office.
3. **Tutorial Phase**: Players first invite the Climate representative, who introduces themselves and provides an overview of their role.
4. **Inviting Other Representatives**: Players then invite the Finance and Society representatives through UI buttons, with each NPC introducing themselves upon arrival.
5. **Representative Discussions**: Each NPC walks to the table and presents their perspective on the current urban planning topic.
6. **Satisfaction Indicators**: Above each NPC's head, a satisfaction meter is displayed, indicating their approval of the player's decisions.
7. **Decision Making**: Players must make decisions based on the input from the representatives, affecting their satisfaction levels.
8. **Rounds of Discussion**: The game consists of 3 rounds, each with new topics and decisions.
9. **Overwhelm Mechanic**: At the end of Round 3, the player experiences a moment of overwhelm, expressed through an inner monologue ("I can't make everyone happy").
10. **Drees & Sommer Intervention**: A UI element provides the player's character with the contact information of Drees & Sommer. On clicking, three team members join the table, introduce themselves, and explain how they can help.
11. **Resolution**: The intervention by Drees & Sommer raises the satisfaction levels of all NPCs, leading to a positive conclusion.
12. **Game End**: The game ends with all stakeholders happy, and the player is prompted to start a new game or exit.

### b. Mechanics
- **Decision Making**: Choose between different urban planning proposals, each with its own set of trade-offs and consequences.
- **Satisfaction Management**: Players need to balance the satisfaction levels of all representatives through their decisions.

### c. Controls
- **Mouse Click or Touchscreen Tap**: Select representatives and interact with the user interface elements.

### d. Formal Objectives
- **Integration**: Successfully integrate various proposals into a cohesive and sustainable city plan.
- **Balance**: Balance the needs and interests of different stakeholders to achieve optimal outcomes for the city.
- **Satisfaction**: Ensure high satisfaction levels among all representatives by addressing their concerns and incorporating their proposals effectively.

### e. Sensory Objectives
- **Visual Cues**: Indicate urgency and stress with visual signals such as blinking icons and color changes.
- **Audio Cues**: Use sound alerts to signal new messages, the arrival of representatives, and important events during the discussions.

### f. Failure States
- **Inherent Unhappiness**: It is impossible to make all representatives happy with every decision, reflecting the inherent complexity and trade-offs in urban planning.

&ensp;

## 4. Visual Style
- **Realistic Office Environment**: A detailed 3D representation of a modern office setting, providing an immersive experience.
- **Round Table**: The central element symbolizing equality and collaborative discussion among stakeholders.
- **Representative Avatars**: Distinct and professional appearances for each type of representative, ensuring clear identification.
- **UI Elements**: Clear and intuitive buttons and indicators for actions and statuses.

&ensp;

## 5. Further Development Ideas

### a. Multiplayer Mode
Allow multiple players to collaborate or compete in urban planning scenarios, enhancing the interactive and educational aspects of the game.

### b. VR Support
Integrate virtual reality to provide an even more immersive experience, allowing players to feel as if they are truly part of the urban planning discussions.

### c. Scenario Expansion
Add more diverse and complex urban planning challenges, including different cities, environmental concerns, and cultural contexts to broaden the educational scope.

### d. Detailed Feedback System
Provide players with in-depth analysis of their decisions, including the long-term impacts of their urban planning choices and how well they balanced stakeholder needs.
