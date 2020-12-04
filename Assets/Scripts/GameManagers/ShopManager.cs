using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public MultiplayerGameManager gm;
    public TextMeshProUGUI currentMoneyText;
    public ShopEntry largeShellEntry;
    public ShopEntry railgunEntry;

    // prices
    public int largeShellPrice = 30;
    public int railGunPrice = 50;

    public void buyLargeShell()
    {
        Tank player = gm.getCurrentPlayerTank();
        TankAmmo ammo = player.GetComponent<TankAmmo>();
        TankMoney money = player.GetComponent<TankMoney>();
        ammo.largeShellAmmo++;
        money.currentMoney -= largeShellPrice;
    }

    public void buyRailgun()
    {
        Tank player = gm.getCurrentPlayerTank();
        TankMoney money = player.GetComponent<TankMoney>();
        TankAmmo ammo = player.GetComponent<TankAmmo>();
        ammo.railgunAmmo++;
        money.currentMoney -= railGunPrice;
    }

    public void updateShopScreen()
    {
        Tank player = gm.getCurrentPlayerTank();
        TankMoney money = player.GetComponent<TankMoney>();
        int currentFunds = money.currentMoney;
        currentMoneyText.text = "Current Money: " + currentFunds.ToString();
        largeShellEntry.setPrice(largeShellPrice);
        railgunEntry.setPrice(railGunPrice);
        if(currentFunds < largeShellPrice)
        {
            largeShellEntry.disableEntry();
        }
        else
        {
            largeShellEntry.enableEntry();
        }
        if(currentFunds < railGunPrice)
        {
            railgunEntry.disableEntry();
        }
        else
        {
            railgunEntry.enableEntry();
        }
    }
    

    
}
