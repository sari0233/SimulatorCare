using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HeadMovementFuelBarrel : MonoBehaviour
{
    public InputActionReference headMovementAction; // Input action for detecting head movement.
    public float headMovementThreshold = 0.5f; // Threshold for detecting head movement.
    public int headMovementCount = 3; // Number of head movements required to collect the fuel barrel.

    private int currentHeadMovementCount = 0; // Counter for head movements.
    private bool isMovementDetected = false; // Whether movement is currently being detected.
    private bool isFuelBarrelCollected = false; // Whether the fuel barrel has been collected.

    void Update()
    {
        if (!isFuelBarrelCollected && !isMovementDetected && headMovementAction.action.ReadValue<float>() >= headMovementThreshold)
        {
            // Head movement is detected.
            isMovementDetected = true;
            currentHeadMovementCount++;
        }
        else if (isMovementDetected && headMovementAction.action.ReadValue<float>() < headMovementThreshold)
        {
            // Head movement is no longer being detected.
            isMovementDetected = false;
        }

        // Check if the required number of head movements have been made to collect the fuel barrel.
        if (!isFuelBarrelCollected && currentHeadMovementCount >= headMovementCount)
        {
            CollectFuelBarrel(); // Collect the fuel barrel.
            currentHeadMovementCount = 0; // Reset the counter.
        }
    }

    void CollectFuelBarrel()
    {
        // Code to collect the fuel barrel.
        gameObject.SetActive(false); // Disable the fuel barrel game object.
        isFuelBarrelCollected = true; // Set the fuel barrel as collected.
        // Add any other code you need to perform when the fuel barrel is collected.
    }
}
