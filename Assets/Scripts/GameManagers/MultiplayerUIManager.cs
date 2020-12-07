using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MultiplayerUIManager : MonoBehaviour
{
    //This class should handle updating any UI elements that are updated every frame (i.e fuelSlider)
    //Any UI elements that are updated at the beginning of a turn should probably be updated in GameManager

    public MultiplayerGameManager man;
    public Slider fuelSlider;
    public Slider healthSlider;

    public Slider forceSlider;
    public TextMeshProUGUI powerPercentText;

    public AmmoButton basicShellButton;
    public AmmoButton largeShellButton;
    public AmmoButton railgunButton;

    public GameObject destroyedText;

    public GameObject playerWinUI;
    public TextMeshProUGUI winText;

    private const float MAX_POWER = 20;
    private const float MIN_POWER = 5;
    // Update is called once per frame
    void Update()
    {
        updateFuelSlider();
        updateHealthSlider();
        powerPercentText.text = (int) Mathf.Ceil((forceSlider.value - MIN_POWER) * (100 / (MAX_POWER - MIN_POWER)))+ "%";
    }


    public void updateForceSlider()
    {
        TankFire fireObj = man.getCurrentPlayerTank().GetComponent<TankFire>();
        forceSlider.value = fireObj.launchForce;
        powerPercentText.text = (int) Mathf.Ceil((forceSlider.value - MIN_POWER) * (100 / (MAX_POWER - MIN_POWER)))+ "%";
    }


    private void updateFuelSlider()
    {
            fuelSlider.value = man.getCurrentPlayerTank().currentFuel;
    }

    private void updateHealthSlider()
    {
        if (man.getCurrentPlayerTank() != null) {
            healthSlider.value = man.getCurrentPlayerTank().GetComponent<TankHealth>().currentHealth;
        }
    }

    public void changeAmmoType(string typeId)
    {
        TankAmmo ammo = man.getCurrentPlayerTank().gameObject.GetComponent<TankAmmo>();
        string currentId = ammo.currentWeaponId;
        if (!currentId.Equals(typeId))
        {
            ammo.currentWeaponId = typeId;
        }

    }

    public AmmoButton getAmmoButtonById(string id)
    {
        if (id.Equals(Constants.basicShellId))
        {
            return basicShellButton;
        }
        else if (id.Equals(Constants.largeShellId))
        {
            return largeShellButton;
        }
        else
        {
            return railgunButton;
        }
    }


    /*
     * You need to call this whenever something that would affect the state of the ammo button occurs
     * The instances where this is the case are when you fire and when you buy something in the shop
     * This should only ever be called from a manager.
     */
    public void UpdateAmmoButtons()
    {
        TankAmmo ammo = man.getCurrentPlayerTank().gameObject.GetComponent<TankAmmo>();
        ammo.checkState();
        int largeShellNum = ammo.largeShellAmmo;
        int railgunNum = ammo.railgunAmmo;
        largeShellButton.updateQuantity(largeShellNum);
        railgunButton.updateQuantity(railgunNum);
        getAmmoButtonById(ammo.currentWeaponId).selectButton();

    }


}
