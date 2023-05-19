using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ArmMovementFuelBarrel : MonoBehaviour
{
    public InputActionReference armMovementAction; // Input action for detecting arm movement.
    public float armMovementThreshold = 0.5f; // Threshold for detecting arm movement.
    public int armMovementCount = 5; // Number of arm movements required to collect the fuel barrel.

    private int currentArmMovementCount = 0; // Counter for arm movements.
    private bool isMovementDetected = false; // Whether movement is currently being detected.
    private bool isFuelBarrelCollected = false; // Whether the fuel barrel has been collected.

    void Update()
    {
        if (!isFuelBarrelCollected && !isMovementDetected && armMovementAction.action.ReadValue<float>() >= armMovementThreshold)
        {
            // Arm movement is detected.
            isMovementDetected = true;
            currentArmMovementCount++;
        }
        else if (isMovementDetected && armMovementAction.action.ReadValue<float>() < armMovementThreshold)
        {
            // Arm movement is no longer being detected.
            isMovementDetected = false;
        }

        // Check if the required number of arm movements have been made to collect the fuel barrel.
        if (!isFuelBarrelCollected && currentArmMovementCount >= armMovementCount)
        {
            CollectFuelBarrel(); // Collect the fuel barrel.
            currentArmMovementCount = 0; // Reset the counter.
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
