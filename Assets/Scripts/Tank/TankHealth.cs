using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour, Health
{
    public float MaxHealth = 100;
    public float currentHealth = 100;
    public Slider miniHealthSlider;
    public TankMoney money;

    public void dealDamage(float dam)
    {
        currentHealth -= dam;
         miniHealthSlider.value = currentHealth;
        if(currentHealth <= 0)
        {
            money.onPlayerKilled();
            killTank();
        }
        else 
        {
            money.onPlayerDamaged();
            StartCoroutine(UpdateMiniHealthSlider());
        }
    }

    public void killTank()
    {
        //play death anim/particle effects first
        Destroy(gameObject);
    }

    IEnumerator UpdateMiniHealthSlider()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        miniHealthSlider.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        miniHealthSlider.gameObject.SetActive(false);
    }
}
