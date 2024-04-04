using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Common : Enemy
{
    public override void Set()
    {
        _target = Player.Instance.Transform;

        _hp = 3;
        _speed = 0.02f;
        _power = 1;
    }


    public override void Move()
    {        
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed);
    }

    public override void Die()
    {
        EnemySpawner.Instance.PushToPool("Enemy_Common", gameObject);

        Player.Instance.AddExp(30);
    }

}
