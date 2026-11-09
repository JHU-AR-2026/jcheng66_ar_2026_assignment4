# jcheng66_ar_2026_assignment4

Name: Terry Cheng (jcheng66)

This is the Assignment 4 Repo for Intro to Augmented Reality. It contains the Unity code for the game (Q2) and the Python scipts for the 1D Kalman filter (Q1).

## Q1: Kalman Filter
### Files included:
- **'Q1e.py'**: This includes my implemented version of the Kalman filter, which includes both prediction and correction. It computes the Kalman gain and corrects the state estimate with each noisy measurement.
- **'Q1f.py'**: This includes the same Python script for the Kalman filter simulation, but it only computes the prediction and does not update/correct the prediction.
Both files run on Jupyter Notebook.

## Q2: Unity Game
### How to run:
1. Open **Unity Hub**, click **Add → Add project from disk**, and pick the `Q2/` folder.
2. Open it with Unity 6000.6.6f1. The first import can take a few minutes.
3. In the Project window, open **`Assets/Scenes/MainScene.unity`**.
4. Press **Play**, then click **START GAME**.

### Controls:
| Action | Key |
|--------|-----|
| Move   | WASD / arrow keys |
| Jump   | Space (only when on the ground) |

### Gameplay:
1. The ball stays frozen until you click **START GAME**.
2. Roll into all **8 collectible cubes**. The HUD shows `Collected: X/8`.
3. After you collect all 8, a **power-up capsule** appears. Picking it up gives you **4× speed**, turns the ball magenta, and shows `POWER-UP ACTIVE!`.
4. With the power-up active, you can **break the special wall** by running into it. You can't break it without the power-up.
5. Reach the **goal zone** to see `YOU WIN!!`.


