using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    // Start is called before the first frame update
    void Start()
    {
        AttackSpd = 0.8f;
        WaitTime = AttackSpd;
    }

    public override void Attack()
    {
        Collider2D[] TargetArray = Physics2D.OverlapCircleAll(transform.position, 8);
        Transform Target = null;
        float TargetDistance = float.MaxValue;

        foreach (Collider2D target in TargetArray)
        {
            if (target.tag == "Enemy")
            {
                float distance = Vector2.Distance(transform.position, target.transform.position);

                if (distance < TargetDistance)
                {
                    TargetDistance = distance;
                    Target = target.transform;
                }
            }
        }

        if (Target != null)
        {
            BulletSpawner.Instance.Spawn_BulletPistol(WeaponIDX, Target);
        }
    }
}
