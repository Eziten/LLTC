using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : ObjectPool<EnemySpawner>
{
    List<Vector3> PosList = new List<Vector3>();
    
    public void Spawn_EnemyCommon(int _SpawnCnt)
    {
        PosList.Clear();

        for (int i = 0; i < _SpawnCnt; i++)
        {
            Vector3 _pos = GetRandomPos();

            EffectSpawner.Instance.Spawn_EffectSpawn(_pos);

            PosList.Add(_pos);         
        }        

        StartCoroutine(SpawnEnemy(1.2f));
    }
     
    IEnumerator SpawnEnemy(float _delay)
    {
        yield return new WaitForSeconds(_delay);

        for (int i = 0; i < PosList.Count; i++)
        {
            GameObject _Enemy = PopFromPool("Enemy_Common", transform);

            _Enemy.transform.position = PosList[i];
            _Enemy.SetActive(true);
        }
    }

    Vector3 GetRandomPos()
    {
        float Top = Mathf.Min(StageMgr.Instance.GetWallPos(0), CameraController.Instance.Top);
        float Bottom = Mathf.Max(StageMgr.Instance.GetWallPos(1), CameraController.Instance.Bottom);
        float Left = Mathf.Max(StageMgr.Instance.GetWallPos(2), CameraController.Instance.Left);
        float Right = Mathf.Min(StageMgr.Instance.GetWallPos(3), CameraController.Instance.Right);

        float posX = Random.Range(Left, Right);
        float posY = Random.Range(Bottom, Top);
        
        Vector3 pos = new Vector3(posX, posY, 0);

        return pos;
    }
}
