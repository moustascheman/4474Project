using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class railgunProjectile : Projectile
{
    public LayerMask hitboxMask;
    public float base_damage = 70;

    public override void OnCollisionEnter2D(Collision2D col)
    {
       //Destroy projectile on enter
        base.OnCollisionEnter2D(col);
    }

    public override void OnTriggerEnter2D(Collider2D col)
    {
        //the projectile can pierce multiple players/targets
        //should only be destroyed at end of lifetime or collision with ground
        Vector2 projectilePosition = gameObject.transform.position;
        if ((hitboxMask.value & (1 << col.gameObject.layer)) > 0)
        {
            Debug.Log("Direct HIT");
            col.gameObject.GetComponentInParent<Health>().dealDamage(base_damage);
        }
    }
}
