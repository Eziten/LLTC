using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : ObjectPool<ItemSpawner>
{
    public void Spawn_ItemExp(Vector3 _SpawnPos)
    {
        GameObject _ItemExp = PopFromPool("Item_Exp", transform);

        _ItemExp.transform.position = _SpawnPos;
        _ItemExp.SetActive(true);
    }
}
