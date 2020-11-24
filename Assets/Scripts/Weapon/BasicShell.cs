using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicShell : Projectile
{

    public float base_damage = 20;
    public float explosion_rad;

    public override void OnCollisionEnter2D(Collision2D col)
    {

        base.OnCollisionEnter2D(col);
    }

    public override void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.layer == LayerMask.NameToLayer("Hitbox"))
        {
            col.gameObject.GetComponentInParent<TankHealth>().dealDamage(base_damage);
        }

        base.OnTriggerEnter2D(col);
    }


}
