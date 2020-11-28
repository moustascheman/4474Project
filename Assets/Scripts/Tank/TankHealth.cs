using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankHealth : MonoBehaviour, Health
{
    public float MaxHealth = 100;
    public float currentHealth = 100;

    public void dealDamage(float dam)
    {
        currentHealth -= dam;
        if(currentHealth <= 0)
        {
            killTank();
        }
    }

    public void killTank()
    {
        //play death anim/particle effects first
        Destroy(gameObject);
    }
}
