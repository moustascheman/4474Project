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
        Collider2D[] cols = Physics2D.OverlapCircleAll(col.transform.position, explosion_rad, hitboxMask);
        foreach(Collider2D tankCol in cols)
        {
            
            Health health = tankCol.gameObject.GetComponentInParent<Health>();
            float dam = calculateDamage(col.transform.position, tankCol.transform.position);
            health.dealDamage(dam);
            Debug.Log("Dealt " + dam + " damage");

        }
        base.OnCollisionEnter2D(col);
    }

    public override void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.name);
        if ((hitboxMask.value & (1 << col.gameObject.layer)) > 0 )
        {
            Debug.Log("HIT");
            col.gameObject.GetComponentInParent<Health>().dealDamage(base_damage);
        }
        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, explosion_rad, hitboxMask);
        foreach(Collider2D tankCol in cols)
        {
            if(tankCol != col)
            {
                Health health = tankCol.gameObject.GetComponentInParent<Health>();
                float dam = calculateDamage(col.transform.position, tankCol.transform.position);
                health.dealDamage(dam);
                Debug.Log("Dealt " + dam + " damage");
            }
        }

        base.OnTriggerEnter2D(col);
    }

    private float calculateDamage(Vector3 sourcePos, Vector3 destPos)
    {

        float dist = Vector2.Distance(sourcePos, destPos);
        Debug.Log("DISTANCE " + dist);
        float relativeDist = (explosion_rad - dist) / explosion_rad;
        float dam = base_damage * relativeDist;
        dam = Mathf.Max(0f, dam);
        return dam;
    }

}
