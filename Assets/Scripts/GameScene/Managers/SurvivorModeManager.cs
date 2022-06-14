using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivorModeManager : MonoBehaviour
{
    [SerializeField]
    private GameObject fixedPursuitPre;
    [SerializeField]
    private GameObject movedPursuitPre;

    private float spawnDelay = 5f;
    private float curDelay = 0f;

    public int curPursuitSpawnCount = 0;
    protected int FixedPursuitSpawnCount = 0;
    protected int MovedPursuitSpawnCount = 0;
    protected int pursuitSpawnCount = 0;

    public GameObject player;

    protected virtual void Update()
    {
        curDelay += Time.deltaTime;

        SpawnPurusit();
    }

    /// <summary>
    /// 소환 규칙 : 단계만큼 고정 적 추가소환, 단계가 짝수일 때 이동가능한 적 + 1
    /// </summary>

    protected virtual void SpawnPurusit()
    {
        for(int i = 0; i < FixedPursuitSpawnCount; i++)
        {
            if(curDelay >= spawnDelay)
            {
                SpawnFixedPursuit();
                curPursuitSpawnCount++;
                pursuitSpawnCount++;
                curDelay = 0;
                Debug.Log("Spawn FixedPursuit");
            }
        }

        for (int i = 0; i < MovedPursuitSpawnCount; i++)
        {
            if (curDelay >= spawnDelay)
            {
                SpawnMovedPursuit();
                curPursuitSpawnCount++;
                                pursuitSpawnCount++;
                curDelay = 0f;
                Debug.Log("Spawn MovedPursuit");
            }
        }
    }

    protected virtual void SpawnFixedPursuit()
    {
        float spawnPosX = Random.Range(player.transform.position.x + 50f, player.transform.position.x + 450f);
        float spawnPosY = Random.Range(player.transform.position.y + 50f, player.transform.position.y + 450f);
        float spawnPosZ = Random.Range(player.transform.position.z + 50f, player.transform.position.z + 450f);

        Vector3 spawnPos = new Vector3(spawnPosX, spawnPosY, spawnPosZ);

        // Instantiate(fixedPursuitPre, spawnPos, Quaternion.identity);
    }

    protected virtual void SpawnMovedPursuit()
    {
        float spawnPosX = Random.Range(player.transform.position.x - 50f, player.transform.position.x + 50f);
        float spawnPosY = Random.Range(player.transform.position.y - 50f, player.transform.position.y + 450f);
        float spawnPosZ = Random.Range(player.transform.position.z - 50f, player.transform.position.z + 450f);

        Vector3 spawnPos = new Vector3(spawnPosX, spawnPosY, spawnPosZ);

        Instantiate(movedPursuitPre, spawnPos, Quaternion.identity);
    }

    protected virtual void goNextLevel()
    {
        if(pursuitSpawnCount >= FixedPursuitSpawnCount + MovedPursuitSpawnCount && curPursuitSpawnCount <= 0)
        {
            LevelManager.FindObjectOfType<LevelManager>().nextLevel();
        }
    }
}
