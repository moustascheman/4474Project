using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankFire : MonoBehaviour
{

    public Rigidbody2D ProjectileObject;
    public Transform fireTransform;
    public float launchForce;
    public TankAmmo ammo;



    /*
     * Fires a projectile
     * Should probably be modified to take in launch force as a param
     */

    public Rigidbody2D Fire()
    {
        ProjectileObject = ammo.getCurrentProjectile().GetComponent<Rigidbody2D>();
        ammo.decrementCurrentAmmo();
        Rigidbody2D projectileInstance = Instantiate(ProjectileObject, fireTransform.position, fireTransform.rotation) as Rigidbody2D;

        //Velocity can be used instead, BUT that means that mass doesn't factor at all into force calculations
        //Using delta time makes it slower but you shouldn't use that since it seems like that makes projectile arcs non-deterministic (somewhat random)

        projectileInstance.AddForce(fireTransform.up*launchForce, ForceMode2D.Impulse);

        //You need to return the projectile Instance so the manager can track it
        return projectileInstance;
 
    }

}
