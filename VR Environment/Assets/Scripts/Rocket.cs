using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{
    public GameObject[] fuelBarrels;

    private bool hasAllFuel = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Check if player has all fuel barrels
            Inventory inventory = other.gameObject.GetComponent<Inventory>();
            if (inventory.fuelCount >= fuelBarrels.Length)
            {
                hasAllFuel = true;
            }

            // Show message based on whether player has all fuel barrels
            if (hasAllFuel)
            {
                Debug.Log("You have enough fuel to launch the rocket!");
            }
            else
            {
                Debug.Log("You need to collect all the fuel barrels first.");
            }
        }
    }

    public void LaunchRocket()
    {
        if (hasAllFuel)
        {
            SceneManager.LoadScene("WinScene");
        }
        else
        {
            Debug.Log("You need to collect all the fuel barrels first.");
        }
    }
}