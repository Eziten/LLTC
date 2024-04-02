using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : ObjectPool<BulletSpawner>
{
    [SerializeField] Transform[] _SpawnPos;

    public void Spawn_BulletPistol(int _SpawnIDX, Transform _target)
    {
        GameObject _Bullet = PopFromPool("Bullet_Pistol", transform);

        _Bullet.transform.position = new Vector3(_SpawnPos[_SpawnIDX].position.x, _SpawnPos[_SpawnIDX].position.y, 0);
        _Bullet.GetComponent<Bullet_Pistol>().SetTarget(_target);
        _Bullet.SetActive(true);
    }
}
