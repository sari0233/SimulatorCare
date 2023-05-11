using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Rocket : MonoBehaviour
{
    public int requiredFuelBarrels = 3; // Number of fuel barrels required to launch the rocket.
    public XRController buttonController; // The controller used to initiate the rocket launch sequence.
    public float launchDelay = 3f; // Delay before launching the rocket.

    private int currentFuelBarrelCount = 0; // Counter for collected fuel barrels.
    private bool isLaunching = false; // Whether the rocket is currently launching.

    private void OnEnable()
    {
        buttonController.inputDevice.SelectPress.AddListener(OnLaunchButtonPressed);
    }

    private void OnDisable()
    {
        buttonController.inputDevice.SelectPress.RemoveListener(OnLaunchButtonPressed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FuelBarrel"))
        {
            currentFuelBarrelCount++;
            other.gameObject.SetActive(false); // Disable the collected fuel barrel.
            // Add any other code you need to perform when a fuel barrel is collected.
        }
    }

    private void OnLaunchButtonPressed(XRBaseController controller)
    {
        if (currentFuelBarrelCount >= requiredFuelBarrels && !isLaunching)
        {
            StartCoroutine(LaunchRocketSequence());
        }
    }

    private IEnumerator LaunchRocketSequence()
    {
        isLaunching = true;
        // Add any other code you need to perform before launching the rocket, such as playing an animation or sound effect.
        yield return new WaitForSeconds(launchDelay);
        // Code to launch the rocket, such as starting a particle effect or changing the scene.
        Debug.Log("Rocket launched!");
        // Add any other code you need to perform after launching the rocket.
    }
}
