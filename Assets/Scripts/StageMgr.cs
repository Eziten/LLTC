using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMgr : SingleTon<StageMgr>
{
    /// <summary>
    /// 0 : 상
    /// 1 : 하
    /// 2 : 좌
    /// 3 : 우
    /// </summary>
    [SerializeField] GameObject[] Walls;

    int[] EnemySpawnCntArray = new int[] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };
    int MaxWaveCnt;
    int WaveCnt;
    int SpawnCnt;

    // Start is called before the first frame update
    void Start()
    {
        SpawnCnt = 5;
        MaxWaveCnt = EnemySpawnCntArray.Length;
        WaveCnt = 0;

        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemy()
    {
        /*
        while (WaveCnt < MaxWaveCnt)
        {
            yield return new WaitForSeconds(5.0f);

            EnemySpawner.Instance.Spawn_EnemyCommon(EnemySpawnCntArray[WaveCnt]);

            WaveCnt++;
        } 
        */
        // 테스트 코드
        while (true)
        {
            EnemySpawner.Instance.Spawn_EnemyCommon(SpawnCnt);

            WaveCnt++;

            if (WaveCnt % 3 == 0)
            {
                SpawnCnt++;
            }

            yield return new WaitForSeconds(5.0f);            
        }
    }

    public float GetWallPos(int _dir)
    {
        switch (_dir)
        {
            default:
                return Walls[_dir].transform.position.y - 1f;
            case 1:            
                return Walls[_dir].transform.position.y + 1f;
            case 2:
                return Walls[_dir].transform.position.x + 1f;
            case 3:
                return Walls[_dir].transform.position.x - 1f;
        }
    }
}
