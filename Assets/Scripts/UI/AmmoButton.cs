using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AmmoButton : MonoBehaviour
{
    public TextMeshProUGUI quantityText;
    public Button buttonVisual;
    public GameObject glowLayer;



    public void updateQuantity(int num)
    {
        if(num > 0)
        {
            buttonVisual.interactable = true;
        }
        else
        {
            deselectButton();
            buttonVisual.interactable = false;
        }
        quantityText.text = "x" + num.ToString();

    }

    /*
     * There's a few different approaches we can take to selection in the final UI
     * My suggestion is to add a "border" image game object to each ammo button
     * which we enable/disable on each select/deselect
     *
     * You need to manually set the onclickEvents for the ammo buttons so that they
     * call deselectButton() on the other buttons
     */

    public void selectButton()
    {
        //glowLayer.SetActive(true);
    }

    public void deselectButton()
    {
        //glowLayer.SetActive(false);
    }
}
