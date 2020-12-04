using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


/*
 * Class used for each entry in the shop
 * The class should only control UI elements related to each entry and does not affect player variables such
 * as money and ammo
 */
public class ShopEntry : MonoBehaviour
{
    public Button buyButton;
    public TextMeshProUGUI fundsMessage;

    public void disableEntry()
    {
        buyButton.interactable = false;
        fundsMessage.text = "Not enough money";
    }

    public void enableEntry()
    {
        buyButton.interactable = true;
        fundsMessage.text = "";
    }


}
