# CSOC-GAMEDEV-2025

<p align="center">
  <picture align="center">
    <source media="(prefers-color-scheme: dark)" srcset="[https://i.pinimg.com/originals/f3/e6/4a/f3e64a3c37c4fcaeef74cfef83ff9847.gif](https://i.pinimg.com/originals/ab/76/17/ab761745f01df090ec38b827dd65e58a.gif)">
    <img align="center" alt="Sample GIF" src="https://i.pinimg.com/originals/ab/76/17/ab761745f01df090ec38b827dd65e58a.gif" width="560">
  </picture>
</p>

<p align="center">
  <strong>
  <em>COPS SUMMER OF CODE flagship program of COPS IIT-BHU to make you familiar with open-source and teach you your favourite skills.
    This repo contains resources for GAMEDEV track</em>
  </strong>
</p>

Note-This repo is Unity Peeps. For Godot you can follow this repo(https://github.com/CSOCED/CSOC25-GODOT)

## Goals

By the end, you should be proficient enough to create something awesome!

<table>
<tr>
  
```javascript
 void Start()
{
rb = GetComponent<Rigidbody2D>();
}
void Update(){

transform.Translate(Vector2.right * speed * Time.deltaTime);

isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 1f, groundLayer);

if (Input.GetKeyDown(KeyCode.Space) && isGrounded){

rb.velocity = new Vector2(rb.velocity.x, jumpForce);
}

```

</tr>
<tr>
  <td>
    <img align="center" alt="Anime.js code example" src="https://i.pinimg.com/originals/14/b9/9e/14b99e109b3a1f14dfeaf54bb83f55f8.gif">
  </td>
</tr>
</table>


 ### Git and GitHub

Git is a distributed version control system that allows developers to track changes in their code and collaborate with others. GitHub is a web-based platform that hosts Git repositories and provides additional collaboration features.

**Resources:**
- [Git & GitHub Tutorial](https://youtu.be/q8EevlEpQ2A?si=zMpFSrSSQ8kIM5bI) - Complete beginner One shot
- [Git Cheat Sheet](https://education.github.com/git-cheat-sheet-education.pdf)
# Unity Beginner Setup Guide

## Prerequisites

Before you begin, ensure you're familiar with the following:

- **Unity Editor Setup**
- **Basic Programming Concepts**: variables, `if-else`, `for` loops, etc.

---


## Setup Instructions
  
### 1. Check System Requirements

Your system must meet Unity's minimum hardware and software requirements.

- [Unity System Requirements](https://docs.unity3d.com/2023.1/Documentation/Manual/system-requirements.html)

### 2. Install Unity Hub

Unity Hub is a tool for managing Unity installations, projects, and licenses.

- [Download Unity Hub](https://unity.com/download)

Once installed, create a Unity account if prompted.

### 3. Install Unity Editor

Download **Unity Editor (LTS version)** through Unity Hub. Use the default installation settings.
(Its advisable to download version 2022.3 to easily follow along. Later you can upgrade the editor as per your needs)

> You may **uncheck Visual Studio Community** during installation—we'll use **Visual Studio Code** instead.

### 4. Video Guides (Optional but Recommended)

- Unity Installation Walkthrough: *[Watch here](https://www.youtube.com/watch?v=your-link)*
- Setting up VS Code for Unity: *[Watch here](https://www.youtube.com/watch?v=your-link)*

---
## C# Programming Essentials

### For Beginners

If you've taken a CS101 course, you likely already know the basics. However, C# has a Java-like syntax that can feel verbose.

To build fluency, try solving basic problems in C#. It helps make the syntax second nature.

### If You're New to Programming

No worries! If you have experience in C, you'll find C# to be more structured and descriptive. The verbosity helps in understanding what the code does.

- [Brackeys C# Beginner Playlist](https://www.youtube.com/playlist?list=PLPV2KyIb3jR4u5jX8za5iU1v4I1tfi8mN)

---


<h1>Week 0 Task</h1>

<details>
  <summary><strong>Click to expand Week 0 details</strong></summary>

## Instructions

1. Fork the repository and clone it to your local machine.

2. Open the project in the unity editor.

3. Create a new branch for your work.

4. Inside the `Assets/Problems` folder, you will find four problems. Try to solve them.

5. To check your solutions, go to `Window → General → Test Runner`.

6. In Edit Mode, click **Run All** after writing your code to run the tests.
   <img align="center" alt="Test screen" src="https://i.pinimg.com/736x/3f/48/5e/3f485e5c2a60fda06516eef5f6902c13.jpg" width="560">

7. ### 📌 Important Submission Step

> **Once your solutions are complete and you no longer plan to make changes**, follow these steps:

  . Create a new folder inside the `problems/` directory.  
   **Name it as:** `YourName_RollNumber`  
   _Example:_ `problems/Ayush_2101234`

. Move your solution `.cs` file(s) and the `Problem.asmdef` file into that folder.

8. Raise a pull request and attach the screenshot in the description.

</details>

# Week 1 

<details>
  <summary><strong>Click to expand Week 1 details</strong></summary>

  ### Hola Dear Programmers and Developers,lend me your ears. We Officially Begin with CSOC and this week 1. 

In this week we will be getting familiar with Unity UI, Components,RigidBody Colliders etc and By the end we will have our humble beginnings for something legendary. Lets Begin

## Player Movement

Player movement is one of the fundamental systems in any game. In a **2D platformer**, the movement typically involves navigating left and right on the x-axis and jumping on the y-axis. The goal is to provide responsive and smooth controls that feel satisfying to the player.

In Unity, movement can be handled in multiple ways — the two most common being:

- **Transform-based movement**: Directly modifying the position of a GameObject using its `transform.position`.
- **Rigidbody2D-based movement**: Using Unity's physics engine to move objects by applying velocity or forces through the `Rigidbody2D` component.

For platformers, **Rigidbody2D** is generally preferred because:
- It works well with Unity’s collision system.
- It enables realistic interactions with gravity, friction, and other physics-based behaviors.
- It helps avoid bugs like clipping through platforms or tunneling.

Typical components involved in a 2D platformer character include:
- `Rigidbody2D` – for physics simulation.
- `BoxCollider2D` (or `CapsuleCollider2D`) – for collision detection.
- A movement script that takes input and applies velocity.

To build on this base, platformers often add **jump mechanics**, **air control**, **coyote time**, and **variable jump heights** to enhance gameplay feel.

Next, we'll explore the pros and cons of different movement techniques before implementing horizontal movement.
| **Physics-Based Movement**                           | **Transform-Based Movement**                          |
|------------------------------------------------------|--------------------------------------------------------|
| ✅ Realistic motion with forces, collisions, gravity  | ✅ Direct and simple to implement                      |
| ✅ Works naturally with Rigidbody and physics engine  | ✅ Great for UI or simple object manipulation          |
| ❌ Harder to control precisely (e.g. instant stops)   | ❌ Ignores physics (can clip through objects)          |
| ❌ More performance-heavy in complex scenes           | ❌ No built-in collision or inertia                    |

### For this project we will be using RigidBody movements for player and Transform movements for enemies. Here is how it can look
```csharp
public class PlayerMovement : MonoBehaviour
{
    public float moveForce = 5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 force = new Vector3(x, 0, z) * moveForce;
        rb.AddForce(force);
    }
}
```
[Here is a video about Player Movement](https://youtu.be/K1xZ-rycYY8?feature=shared)

## Rotating objects following Mouse cursor
### 🧠 Math Behind Rotating an Object Toward the Mouse Cursor

In 2D space, rotating an object to face the mouse is fundamentally a problem of **angle determination between two points**. The key idea is to construct a vector from the object’s position to the mouse cursor, and then compute the angle that vector makes with a reference axis — typically the positive X-axis.

---

#### 📐 Geometric Setup

Let:

- `P = (px, py)` — position of the object
- `M = (mx, my)` — position of the mouse cursor
- `D = M - P = (dx, dy)` — direction vector pointing toward the cursor

We want to compute the **angle of vector D with respect to the X-axis**, which is defined by the geometry of the right triangle formed by `(dx, dy)`.

---

#### 🧮 Trigonometric Derivation

Using the right triangle:

- Opposite side: `dy`
- Adjacent side: `dx`
- Hypotenuse: `‖D‖ = sqrt(dx² + dy²)`

Using trigonometry:

- `cos(θ) = dx / ‖D‖`
- `sin(θ) = dy / ‖D‖`
- `tan(θ) = dy / dx`

The angle `θ` that the object must rotate to is given by the **inverse tangent** of the slope:

This angle describes how far to rotate the object **counter-clockwise from the positive X-axis** to point at the mouse.

> 📌 Note: The range of `arctangent` is limited, so to determine the angle correctly in **all four quadrants**, use a function that takes both `dx` and `dy` as inputs. (We'll leave the exact function to your discovery.)

---

#### 🖱️ Mouse Position Access (Unity)

```csharp
// This will give mouse position in Screen pos
Vector3 mousePos = Input.mousePosition;
//convert it to World Pos
mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
// calculate your angle of rotation 😎
//then use it like this

float angleInDeg = calculatedAngleInRad * Mathf.Rad2Deg;
transform.rotation = Quaternion.Euler(0, 0, angleDeg);
```

## Shooting Bullets
[Watch this short](https://youtube.com/shorts/dXg_zpSesgo?si=w1Xea8gYeiTNxhbT)
We always instantiate a [Prefab](https://docs.unity3d.com/Manual/Prefabs.html)
Rotations in unity are dealt with Quaternions. Although as sort of hack you will always see that we use either Quaternion.Identity or transform.rotation when we want no rotations or want the instantiated GameObject to match the rotation of parent respectively. But it is always good to know your maths concept.[Quaternions](https://www.youtube.com/watch?v=zjMuIxRvygQ)

## Spawning Enemies and Its AI
   Now you know about:Movement,rotation and spawning you can create Enemy spawning mechanism and Its very basic AI to follow the player.


## Video Resources
This [video](https://www.youtube.com/watch?v=XtQMytORBmM) will help you getting Idea of Unity Editor and how to work around It. For now, you can skip the UI section.


# Task
- Sync your fork and fetch the updates
- Open the project in editor. In Assets/submissions create a folder with <YourName_RollNumber>
- Copy the template scene in your folder. The template scene looks kinda plain but don't worry it can be converted to something nice. We are just at the prototyping stage
- Add player movement,shooting bullets, the gun rotating according to mouse position and enemy spawning.
- create a PR. The PR should have a video attached of your work.


</details>

# Week 2
<em> Sorry for late task upload</em>
<p align="center">
  <picture align="center">
    <source media="(prefers-color-scheme: dark)" srcset="[https://i.pinimg.com/originals/6f/55/e1/6f55e1dadbe4e0a7f7cc01c5751cdcf2.gif](https://i.pinimg.com/originals/6f/55/e1/6f55e1dadbe4e0a7f7cc01c5751cdcf2.gif)">
    <img align="center" alt="Sample GIF" src="https://i.pinimg.com/originals/6f/55/e1/6f55e1dadbe4e0a7f7cc01c5751cdcf2.gif" width="560">
  </picture>
</p>

### Hola Amigo, Kaise ho Thik ho?. This week will be tackling Parallax, level generation and UI
<p align="center">
  <picture align="center">
    <source media="(prefers-color-scheme: dark)" srcset="[https://i.pinimg.com/originals/99/11/37/9911376abae57e7ea29aa11a47d464dd.gif](https://i.pinimg.com/originals/99/11/37/9911376abae57e7ea29aa11a47d464dd.gif)">
    <img align="center" alt="Sample GIF" src="https://i.pinimg.com/originals/99/11/37/9911376abae57e7ea29aa11a47d464dd.gif" width="560">
  </picture>
</p>

## The Parallax effect
The parallax effect is a visual technique that creates an illusion of depth by moving background layers at different speeds relative to foreground objects. As the camera or player moves, distant objects appear to move slower than nearby objects, mimicking how our eyes perceive depth in the real world.

#### Mathematical Foundation
The core principle relies on inverse linear interpolation based on depth. For a layer at depth <code>z</code> with a reference <code>depth z_ref</code>, the parallax factor is:
<code>parallax_factor = z_ref / z</code>

When the camera moves by displacement <code>Δx</code>, each layer moves by:
<code>layer_displacement = Δx × parallax_factor</code>

Where <code>parallax_strength</code> controls the effect intensity (typically 0.1 to 1.0).
use cinemachine for smooth camera following. You dont need to implement it manually.

## Level Generation


Level generation in endless runners involves creating an infinite, seamless sequence of platforms, obstacles, and collectibles that maintains consistent difficulty progression and player engagement. The system must generate content ahead of the player while destroying passed content to manage memory efficiently.

## Mathematical Foundation

**Chunk-based Generation:**
Divide the level into fixed-width chunks of length `L`. Generate new chunks when the player reaches a threshold distance:
```
generate_trigger = player_x + look_ahead_distance
chunk_index = floor(generate_trigger / L)
```

**Difficulty Scaling:**
Apply exponential or logarithmic difficulty curves:
```
difficulty(x) = base_difficulty × (1 + growth_rate)^(x/scale_factor)
```
Or for smoother scaling:
```
difficulty(x) = max_difficulty × (1 - e^(-growth_rate × x))
```

**Platform Spacing:**
Use Perlin noise or sine waves for organic platform placement:
```
platform_height(x) = amplitude × sin(frequency × x + phase) + base_height
gap_size(x) = min_gap + noise(x × gap_frequency) × gap_variance
```

**Jump Validation:**
Ensure all gaps are traversable by checking jump physics:
```
max_jump_distance = initial_velocity × time_to_peak + 0.5 × gravity × time_to_peak²
```
Where `time_to_peak = initial_velocity / gravity`

**Probability Distribution:**
Use weighted random selection for obstacle types:
```
cumulative_weight = Σ(weight_i) for i ∈ obstacles
selection = random(0, cumulative_weight)
```

## Implementation Overview

Most endless runners use:

1. **Chunk Management System**: Pre-generate chunks in a circular buffer, destroying chunks behind the player. Typically maintain 3-5 chunks: current, next 2-3 ahead, and previous 1-2 for safety.

2. **Template-based Generation**: Create hand-crafted chunk templates with difficulty ratings, then select and modify them procedurally based on current difficulty level and recent history.

3. **Constraint Solving**: Use rule-based systems to ensure generated content follows game rules (no impossible jumps, mandatory collectible placement, safe landing zones after difficult sections).

The key is balancing randomness with predictability—enough variation to feel fresh while maintaining learnable patterns. Many systems use "breathing room" mechanics, inserting easier sections after difficult ones to prevent player frustration and allow skill expression windows.

## Game UI
[This video will help you get an Idea about Game UI](https://www.youtube.com/watch?v=BLfNP4Sc_iA)

## Task Summary
- Create a Parallax background with smooth camera following using cinemachine (or manually if you hate your life). You can use any background asset of your choice. We will not see how your game "looks" in tasks, that is for the final week Game Jam 😜.

- Add a well balanced platoform generation. You can add spiked platoform, stealth spot etc. It has go well with enemy spawning of Week 1
- Add simple Game UI. Health bar is necessary. Additionally, you can try adding Enemy wave countdown time, Or the duration left for using your "Super Move".

Good Luck 👍

<p align="center">
  <picture align="center">
    <source media="(prefers-color-scheme: dark)" srcset="[https://i.pinimg.com/originals/68/d9/ab/68d9ab65ee90c04f7e7a26f8ff80c371.gif](https://i.pinimg.com/originals/68/d9/ab/68d9ab65ee90c04f7e7a26f8ff80c371.gif)">
    <img align="center" alt="Sample GIF" src="https://i.pinimg.com/originals/68/d9/ab/68d9ab65ee90c04f7e7a26f8ff80c371.gif" width="560">
  </picture>
</p>







