using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : ObjectPool<EnemySpawner>
{   
    public void Spawn_EnemyCommon(int _SpawnCnt)
    {
        for (int i = 0; i < _SpawnCnt; i++)
        {
            GameObject _Enemy = PopFromPool("Enemy_Common", transform);

            _Enemy.transform.position = GetRandomPos();
            _Enemy.SetActive(true);
        }
    }

    Vector3 GetRandomPos()
    {
        float posX = Random.Range(CameraController.Instance.Left, CameraController.Instance.Right);
        float posY = Random.Range(CameraController.Instance.Bottom, CameraController.Instance.Top);
        
        Vector3 pos = new Vector3(posX, posY, 0);

        return pos;
    }
}
