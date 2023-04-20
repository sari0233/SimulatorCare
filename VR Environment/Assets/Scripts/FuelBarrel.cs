using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelBarrel : MonoBehaviour
{
    public int fuelValue = 1; // How much fuel this barrel contains
    public AudioClip collectSound; // Sound to play when the barrel is collected

    private bool isCollected = false; // Whether this barrel has already been collected

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            /// Add fuel to inventory
            Inventory inventory = other.gameObject.GetComponent<Inventory>();
            inventory.AddFuel(1);

            // Deactivate the fuel barrel
            gameObject.SetActive(false);
        }
    }
}