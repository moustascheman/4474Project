using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAmmo : MonoBehaviour
{
    //basicShells should have infinite ammo

    //large shell
    public int largeShellAmmo = 0;
    public int largeShellLimit = 5;

    //Railgun
    public int railgunAmmo = 0;
    public int railgunLimit = 5;

    //weapon prefabs
    public GameObject basicShellPrefab;
    public GameObject largeShellPrefab;
    public GameObject railgunPrefab;

    public string currentWeaponId = "BASICSHELL_WEP";

    public GameObject getCurrentProjectile()
    {
        if(currentWeaponId.Equals(Constants.basicShellId)) {
            return basicShellPrefab;
        }
        else if (currentWeaponId.Equals(Constants.largeShellId))
        {
            return largeShellPrefab;
        }
        else
        {
            return railgunPrefab;
        }
    }

    public void checkState()
    {
    //if you run out of ammo in your currently selected weapon you will be defaulted back to basicShell
        if (currentWeaponId.Equals(Constants.largeShellId))
        {
            if (largeShellAmmo <= 0)
            {
                currentWeaponId = Constants.basicShellId;
            }
        }

        else if (currentWeaponId.Equals(Constants.railgunID))
        {
            if(railgunAmmo <= 0)
            {
                currentWeaponId = Constants.basicShellId;
            }
        }
    }
    public void decrementCurrentAmmo()
    {
        if (currentWeaponId.Equals(Constants.largeShellId))
        {
            largeShellAmmo--;
        }

        else if (currentWeaponId.Equals(Constants.railgunID))
        {
            railgunAmmo--;
        }
    }

    

    
}
