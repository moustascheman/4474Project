using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingleplayerUIManager : MonoBehaviour
{
    public SingleplayerGameManager man;
    public AmmoButton basicShellButton;
    public AmmoButton largeShellButton;
    public AmmoButton railgunButton;
    public Slider forceSlider;
    public void changeAmmoType(string typeId)
    {
        TankAmmo ammo = man.player.gameObject.GetComponent<TankAmmo>();
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
     * The instances where this is the case are when you fire
     * This should only ever be called from a manager.
     */
    public void UpdateAmmoButtons()
    {
        TankAmmo ammo = man.player.gameObject.GetComponent<TankAmmo>();
        ammo.checkState();
        int largeShellNum = ammo.largeShellAmmo;
        int railgunNum = ammo.railgunAmmo;
        largeShellButton.updateQuantity(largeShellNum);
        railgunButton.updateQuantity(railgunNum);
        getAmmoButtonById(ammo.currentWeaponId).selectButton();

    }
}
