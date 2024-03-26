using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Common : Enemy
{
    public override void Set()
    {
        _target = Player.Instance.GetTransform();

        _hp = 10;
        _speed = 0.02f;
        _power = 1;
    }


    public override void Move()
    {        
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed);
    }

}
