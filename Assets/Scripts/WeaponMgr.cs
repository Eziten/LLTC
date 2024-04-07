using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMgr : SingleTon<WeaponMgr>
{
    public void Equip_Weapon(string _weaponName, int _equipIDX)
    {
        GameObject _Weapon = ResourceMgr.Instance.Instantiate(_weaponName, Player.Instance.GetWeaponSlot(_equipIDX));

        _Weapon.GetComponent<Weapon>().SetWeaponIDX(_equipIDX);
        Player.Instance.SetWeaponArray(_equipIDX, (WeaponType)Enum.Parse(typeof(WeaponType), _weaponName));
    }
}
