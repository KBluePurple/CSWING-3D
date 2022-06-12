using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivorModeManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pursuitPre;
    [SerializeField]
    private int maxPursuitSpawnCount = 5;
    private int wave = 1;
    private float spawnDelay = 90f;
    private float curDelay = 0f;

    public int curPursuitSpawnCount = 0;
    protected int FixedPursuitSpawnCount = 0;
    protected int MovedPursuitSpawnCount = 0;
    protected int curFixedPursuitSpawnCount = 0;
    protected int curMovedPursuitSpawnCount = 0;

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
        if (curPursuitSpawnCount == 0 || curDelay >= spawnDelay)
        {
            if (curFixedPursuitSpawnCount < FixedPursuitSpawnCount)
            {
                SpawnFixedPursuit();
                curPursuitSpawnCount++;
                curDelay = 0;
                Debug.Log("Spawn FixedPursuit");
            }

            if (curMovedPursuitSpawnCount <= MovedPursuitSpawnCount && curFixedPursuitSpawnCount >= FixedPursuitSpawnCount)
            {
                SpawnMovedPursuit();
                curPursuitSpawnCount++;
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

        Instantiate(pursuitPre, spawnPos, Quaternion.identity);
    }

    protected virtual void SpawnMovedPursuit()
    {
        float spawnPosX = Random.Range(player.transform.position.x - 50f, player.transform.position.x + 50f);
        float spawnPosY = Random.Range(player.transform.position.y - 50f, player.transform.position.y + 450f);
        float spawnPosZ = Random.Range(player.transform.position.z - 50f, player.transform.position.z + 450f);

        Vector3 spawnPos = new Vector3(spawnPosX, spawnPosY, spawnPosZ);

        Instantiate(pursuitPre, spawnPos, Quaternion.identity);
    }
}
