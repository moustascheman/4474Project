using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankFire : MonoBehaviour
{

    public Rigidbody2D ProjectileObject;
    public Transform fireTransform;
    public float launchForce;



    /*
     * Fires a projectile
     * Should probably be modified to take in launch force as a param
     */

    public Rigidbody2D Fire()
    {
        Rigidbody2D projectileInstance = Instantiate(ProjectileObject, fireTransform.position, fireTransform.rotation) as Rigidbody2D;

        //Velocity can be used instead, BUT that means that mass doesn't factor at all into force calculations
        //Using delta time makes it slower but you shouldn't use that since it seems like that makes projectile arcs non-deterministic (somewhat random)

        projectileInstance.AddForce(fireTransform.up*launchForce, ForceMode2D.Impulse);

        //You need to return the projectile Instance so the manager can track it
        return projectileInstance;
 
    }

}
