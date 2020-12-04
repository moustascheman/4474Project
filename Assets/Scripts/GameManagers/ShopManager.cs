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
        ammo.largeShellAmmo++;
        player.money -= largeShellPrice;
    }

    public void buyRailgun()
    {
        Tank player = gm.getCurrentPlayerTank();
        TankAmmo ammo = player.GetComponent<TankAmmo>();
        ammo.railgunAmmo++;
        player.money -= railGunPrice;
    }

    public void updateShopScreen()
    {
        Tank player = gm.getCurrentPlayerTank();
        currentMoneyText.text = "Current Money: " + player.money.ToString();
        largeShellEntry.setPrice(largeShellPrice);
        railgunEntry.setPrice(railGunPrice);
        if(player.money < largeShellPrice)
        {
            largeShellEntry.disableEntry();
        }
        else
        {
            largeShellEntry.enableEntry();
        }
        if(player.money < railGunPrice)
        {
            railgunEntry.disableEntry();
        }
        else
        {
            railgunEntry.enableEntry();
        }
    }
    

    
}
