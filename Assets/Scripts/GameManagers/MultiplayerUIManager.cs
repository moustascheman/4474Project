using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiplayerUIManager : MonoBehaviour
{
    //This class should handle updating any UI elements that are updated every frame (i.e fuelSlider)
    //Any UI elements that are updated at the beginning of a turn should probably be updated in GameManager

    public MultiplayerGameManager man;
    public Slider fuelSlider;

    // Update is called once per frame
    void Update()
    {
        updateFuelSlider();
    }


    private void updateFuelSlider()
    {
        fuelSlider.value = man.getCurrentPlayerTank().currentFuel;
    }
}
