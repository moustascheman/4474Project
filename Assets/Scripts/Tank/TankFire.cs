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

    public void Fire()
    {
        Rigidbody2D projectileInstance = Instantiate(ProjectileObject, fireTransform.position, fireTransform.rotation) as Rigidbody2D;

        //This is a little weird. It basically requires force be set to something insanely low like 0.001
        //Velocity can be used instead, BUT that means that mass doesn't factor at all into force calculations
        //Using delta time makes it slower but you shouldn't use that since it seems like that makes projectile arcs non-deterministic (somewhat random)
        projectileInstance.AddForce(fireTransform.up*launchForce, ForceMode2D.Impulse);
        //TODO : Add projectile lifetime so that they're destroyed after X amount of seconds have passed if they haven't hit anything.
        //TODO : Do not let any user perform any actions (such as firing) until a fired projectile has been resolved, this could be done with the game manager since it will handle turns/gameflow
    }
}
