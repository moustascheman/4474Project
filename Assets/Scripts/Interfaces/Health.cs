using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Interface used to represent health for both tanks (in MP) and targets in SP
public interface Health
{
    // Deal damage to target
    void dealDamage(float dam);


    void killTank();
}
