using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicShell : Projectile
{

    public float base_damage = 20;
    public float explosion_rad;
    public LayerMask hitboxMask;

    public override void OnCollisionEnter2D(Collision2D col)
    {
        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, explosion_rad, hitboxMask);
        foreach(Collider2D tankCol in cols)
        {
            
            TankHealth health = tankCol.gameObject.GetComponentInParent<TankHealth>();

        }
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

    private void calculateDamage(Vector3 sourcePos, Vector3 destPos)
    {


    }

}
