using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Basic Tank Script that handles basic tank functions that can be unified between both modes
//Should be extended with inheritance for MP mode
public class Tank : MonoBehaviour
{
    //Fuel Amount
    public float currentFuel = 100;
    public Slider fuelSlider;
    //Projectiles should fire from this point
    public List<GameObject> Inventory;
    public GameObject firingPoint;

    // Update is called once per frame
    void Update()
    {
        fuelSlider.value = currentFuel;
    }

    //function to decrease fuel
    public void decreaseFuel(){
        currentFuel -= Time.deltaTime * 20;
    }
}
