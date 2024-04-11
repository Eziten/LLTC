using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMgr : SingleTon<StageMgr>
{
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
}
