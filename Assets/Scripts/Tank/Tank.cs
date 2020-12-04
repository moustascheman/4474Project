using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Basic Tank Script that handles basic tank functions that can be unified between both modes
//Should be extended with inheritance for MP mode
public class Tank : MonoBehaviour
{
    public bool isActive;
    public int playerNumber;
    public TextMeshProUGUI playerNumberUI;

    public int money = 0;

    //Fuel Amount
    public float currentFuel = 100;
    public float maxFuel = 100;

    //function to decrease fuel
    public void decreaseFuel(){
        currentFuel -= Time.deltaTime * 20;
    }

    public void setPlayerNumber(){
        playerNumberUI.text = playerNumber.ToString();
    }
}
