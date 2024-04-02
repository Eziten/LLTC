using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    protected int WeaponIDX;
    protected float AttackSpd;
    protected float WaitTime;

    // Update is called once per frame
    void Update()
    {
        WaitTime += Time.deltaTime;

        if (WaitTime > AttackSpd)
        {
            Attack();

            WaitTime = 0;
        }
    }

    public virtual void Attack() { } 

    public void SetWeaponIDX(int _IDX)
    {
        WeaponIDX = _IDX;
    }
}
