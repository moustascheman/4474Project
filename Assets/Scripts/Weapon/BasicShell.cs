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
            float dam = calculateDamageFromClosestPoint(tankCol, col.transform.position);
            health.dealDamage(dam);
            Debug.Log("Dealt " + dam + " damage");

        }
        base.OnCollisionEnter2D(col);
    }

    public override void OnTriggerEnter2D(Collider2D col)
    {
        Vector2 projectilePosition = gameObject.transform.position;
        if ((hitboxMask.value & (1 << col.gameObject.layer)) > 0 )
        {
            Debug.Log("Direct HIT");
            col.gameObject.GetComponentInParent<Health>().dealDamage(base_damage);
        }

        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, explosion_rad, hitboxMask);

        foreach(Collider2D tankCol in cols)
        {
            if(tankCol != col)
            {
                Health health = tankCol.gameObject.GetComponentInParent<Health>();
                float dam = calculateDamageFromClosestPoint(tankCol, projectilePosition);
                health.dealDamage(dam);
                Debug.Log("Dealt " + dam + " damage");
            }
        }

        base.OnTriggerEnter2D(col);
    }

    private float calculateDamageFromClosestPoint(Collider2D col, Vector2 sourcePos)
    {
        Vector2 closestPoint = col.ClosestPoint(sourcePos);
        float dist = Vector2.Distance(closestPoint, sourcePos);
        Debug.Log("DISTANCE " + dist);
        float relativeDist = (explosion_rad - dist) / explosion_rad;
        float dam = base_damage * relativeDist;
        dam = Mathf.Max(0f, dam);
        return dam;
    }

}
