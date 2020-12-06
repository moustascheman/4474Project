using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Basic Tank Script that handles basic tank functions that can be unified between both modes
//Should be extended with inheritance for MP mode
public class Tank : MonoBehaviour
{
    private bool isActive;
    public int playerNumber;
    public TextMeshProUGUI playerNumberUI;
    public GameObject aimingArrow;

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

    public void SetActive(bool isActive) {
        this.isActive = isActive;

        if (isActive) {
            aimingArrow.SetActive(true);
        } else {
            aimingArrow.SetActive(false);
        }
    }

    public bool IsActive() {
        return isActive;
    }
}
