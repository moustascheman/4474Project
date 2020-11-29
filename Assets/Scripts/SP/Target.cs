using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour, Health
{
    // Start is called before the first frame update
    public void dealDamage(float f)
    {
        Debug.Log("TEST");
        //any hit kills a target in one hit
        killTank();
    }

    public void killTank()
    {
        Destroy(gameObject);
    }
}
