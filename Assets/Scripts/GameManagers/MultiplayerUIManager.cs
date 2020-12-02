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

    public AmmoButton basicShellButton;
    public AmmoButton largeShellButton;
    public AmmoButton railgunButton;

    // Update is called once per frame
    void Update()
    {
        updateFuelSlider();
    }


    private void updateFuelSlider()
    {
        fuelSlider.value = man.getCurrentPlayerTank().currentFuel;
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
