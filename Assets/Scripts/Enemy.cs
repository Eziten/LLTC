using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected Transform _target;
    protected float _speed;
    protected float _power;
    protected float _hp;
    
    private void OnEnable() { Set(); }
    private void Update() { if (gameObject.activeSelf) Move(); }    
    public virtual void Set() { }
    public virtual void Move() { }
    public virtual void Attack() { }

    public virtual void Damage(float _damage)
    {
        _hp -= _damage;

        if (_hp < 0)
        {
            Die();
        }
    }

    public virtual void Die() { }
}
