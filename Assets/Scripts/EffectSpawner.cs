using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSpawner : ObjectPool<EffectSpawner>
{
    public void Spawn_EffectSpawn(Vector3 _SpawnPos)
    {
        GameObject _EffectSpawn = PopFromPool("Effect_Spawn", transform);

        _EffectSpawn.transform.position = _SpawnPos;
        _EffectSpawn.SetActive(true);
    }
}
