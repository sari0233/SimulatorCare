using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ArmRotationFuelBarrel : MonoBehaviour
{
    public InputActionReference armRotationAction; // Input action for detecting arm rotations.
    public float armRotationThreshold = 0.5f; // Threshold for detecting arm rotations.
    public int armRotationCount = 3; // Number of arm rotations required to collect the fuel barrel.

    private int currentArmRotationCount = 0; // Counter for arm rotations.
    private bool isRotationDetected = false; // Whether rotation is currently being detected.
    private bool isFuelBarrelCollected = false; // Whether the fuel barrel has been collected.

    void Update()
    {
        if (!isFuelBarrelCollected && !isRotationDetected && armRotationAction.action.ReadValue<float>() >= armRotationThreshold)
        {
            // Arm rotation is detected.
            isRotationDetected = true;
            currentArmRotationCount++;
        }
        else if (isRotationDetected && armRotationAction.action.ReadValue<float>() < armRotationThreshold)
        {
            // Arm rotation is no longer being detected.
            isRotationDetected = false;
        }

        // Check if the required number of arm rotations have been made to collect the fuel barrel.
        if (!isFuelBarrelCollected && currentArmRotationCount >= armRotationCount)
        {
            CollectFuelBarrel(); // Collect the fuel barrel.
            currentArmRotationCount = 0; // Reset the counter.
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
