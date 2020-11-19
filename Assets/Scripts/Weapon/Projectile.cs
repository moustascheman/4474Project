using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/*
 * Projectile class that defines basic functions for a projectile
 * Should be extended for different types of projectiles with weapon-specific implementations
 */


public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Lifetime of projectiles
        Destroy(gameObject, 5f);
    }


    /*
     * This is for environmental collisions
     * The projectile should typically collide with the environnment, get all targets within the blast radius  
     * and deal radius-based damage to each of them.
     */
    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(gameObject);
    }


    /*
     * The player's hitbox should be a trigger.
     * As such, player/target specific operations should be performed here (i.e decrease health)
     * The hit will be a direct hit and so should deal direct damage to the target and radius-based
     * damage to all other targets in the blast radius.
     * This can be overrided for weapon specific behavior
     */
    void OnTriggerEnter2D(Collider2D col)
    {
      //should check layer first to make sure it is a player layer.
        Destroy(gameObject);
    }
}
