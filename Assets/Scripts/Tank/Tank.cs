using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Basic Tank Script that handles basic tank functions that can be unified between both modes
//Should be extended with inheritance for MP mode
public class Tank : MonoBehaviour
{
    public bool isActive;
    public int playerNumber;

    //Fuel Amount
    public float currentFuel = 100;
    public float maxFuel = 100;




    

    // Update is called once per frame
    /*void Update()
    {
        //shouldn't have tanks set fuel slider since this doesn't work with multiple tanks. Better to have a manager handle this.
       // fuelSlider.value = currentFuel;
    }*/

    //function to decrease fuel
    public void decreaseFuel(){
        currentFuel -= Time.deltaTime * 20;
    }
}
