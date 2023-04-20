using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int fuelCount = 0;
    public Text fuelText;

    public void UpdateFuelText()
    {
        fuelText.text = "Fuel: " + fuelCount;
    }

    public void AddFuel(int amount)
    {
        fuelCount += amount;
        UpdateFuelText();
    }

    void Update()
    {
        fuelText.text = "Fuel: " + fuelCount;
    }
}