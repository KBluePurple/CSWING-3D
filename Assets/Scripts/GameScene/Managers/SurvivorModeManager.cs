using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivorModeManager : MonoBehaviour
{
    [SerializeField]
    private GameObject fixedPursuitPre;
    [SerializeField]
    private GameObject movedPursuitPre;
    [SerializeField]
    private GameObject smallPursuitPre;
    [SerializeField]
    private GameObject middlePursuitPre;
    [SerializeField]
    private GameObject bigPursuitPre;

    public int curPursuitSpawnCount = 0;
    public int curSmallPursuitSpawnCount = 0;
    public int curMiddlePursuitSpawnCount = 0;
    public int curBigPursuitSpawnCount = 0;
    protected int FixedPursuitSpawnCount = 0;
    protected int MovedPursuitSpawnCount = 0;
    protected int smallPursuitSpawnCount = 0;
    protected int middlePursuitSpawnCount = 0;
    protected int bigPursuitSpawnCount = 0;
    protected int pursuitSpawnCount = 0;

    public GameObject player;
    private LevelManager levelManager = null;
    public List<GameObject> enemyList = null;

    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        enemyList = new List<GameObject>();
        StartCoroutine(SpawnPurusit());
    }

    private void Update()
    {
        foreach (GameObject enemy in enemyList)
        {
            if (enemy == null)
            {
                enemyList.Remove(enemy);
                break;
            }
        }
    }

    /// <summary>
    /// 소환 규칙 : 단계만큼 고정 적 추가소환, 단계가 짝수일 때 이동가능한 적 + 1
    /// </summary>
    protected virtual IEnumerator SpawnPurusit()
    {
        for (int i = 0; i < FixedPursuitSpawnCount; i++)
        {
            SpawnFixedPursuit();
            curPursuitSpawnCount++;
            pursuitSpawnCount++;
            Debug.Log("Spawn FixedPursuit");
            yield return new WaitForSeconds(5f);
        }

        for (int i = 0; i < MovedPursuitSpawnCount; i++)
        {
            SpawnMovedPursuit();
            curPursuitSpawnCount++;
            pursuitSpawnCount++;
            Debug.Log("Spawn MovedPursuit");
            yield return new WaitForSeconds(5f);
        }

        for (int i = 0; i < smallPursuitSpawnCount; i++)
        {

            SpawnSmallPursuit();
            curSmallPursuitSpawnCount++;
            pursuitSpawnCount++;
            Debug.Log("Spawn MovedPursuit");
            yield return new WaitForSeconds(5f);

        }

        for (int i = 0; i < middlePursuitSpawnCount; i++)
        {

            SpawnMiddlePursuit();
            curMiddlePursuitSpawnCount++;
            pursuitSpawnCount++;
            Debug.Log("Spawn MovedPursuit");
            yield return new WaitForSeconds(5f);

        }

        for (int i = 0; i < bigPursuitSpawnCount; i++)
        {

            SpawnBigPursuit();
            curBigPursuitSpawnCount++;
            pursuitSpawnCount++;
            Debug.Log("Spawn MovedPursuit");
            yield return new WaitForSeconds(5f);

        }
    }

    protected virtual void SpawnFixedPursuit()
    {
        float spawnPosX = Mathf.Clamp(Random.Range(player.transform.position.x + 50f, player.transform.position.x + 450f), -450f, 450f);
        float spawnPosY = Mathf.Clamp(Random.Range(player.transform.position.y + 50f, player.transform.position.y + 450f), -450f, 450f);
        float spawnPosZ = Mathf.Clamp(Random.Range(player.transform.position.z + 50f, player.transform.position.z + 450f), -450f, 450f);

        Vector3 spawnPos = new Vector3(spawnPosX, spawnPosY, spawnPosZ);

        GameObject enemy = Instantiate(fixedPursuitPre, spawnPos, Quaternion.identity);
        enemyList.Add(enemy);
    }

    protected virtual void SpawnMovedPursuit()
    {
        float spawnPosX = Mathf.Clamp(Random.Range(player.transform.position.x - 50f, player.transform.position.x + 50f), -450f, 450f);
        float spawnPosY = Mathf.Clamp(Random.Range(player.transform.position.y - 50f, player.transform.position.y + 450f), -450f, 450f);
        float spawnPosZ = Mathf.Clamp(Random.Range(player.transform.position.z - 50f, player.transform.position.z + 450f), -450f, 450f);

        Vector3 spawnPos = new Vector3(spawnPosX, spawnPosY, spawnPosZ);

        GameObject enemy = Instantiate(movedPursuitPre, spawnPos, Quaternion.identity);
        enemyList.Add(enemy);
    }

    protected virtual void SpawnSmallPursuit()
    {
        float spawnPosX = Mathf.Clamp(Random.Range(player.transform.position.x - 50f, player.transform.position.x + 50f), -450f, 450f);
        float spawnPosY = Mathf.Clamp(Random.Range(player.transform.position.y - 50f, player.transform.position.y + 450f), -450f, 450f);
        float spawnPosZ = Mathf.Clamp(Random.Range(player.transform.position.z - 50f, player.transform.position.z + 450f), -450f, 450f);

        Vector3 spawnPos = new Vector3(spawnPosX, spawnPosY, spawnPosZ);

        GameObject enemy = Instantiate(smallPursuitPre, spawnPos, Quaternion.identity);
        enemyList.Add(enemy);
    }

    protected virtual void SpawnMiddlePursuit()
    {
        float spawnPosX = Mathf.Clamp(Random.Range(player.transform.position.x - 50f, player.transform.position.x + 50f), -450f, 450f);
        float spawnPosY = Mathf.Clamp(Random.Range(player.transform.position.y - 50f, player.transform.position.y + 450f), -450f, 450f);
        float spawnPosZ = Mathf.Clamp(Random.Range(player.transform.position.z - 50f, player.transform.position.z + 450f), -450f, 450f);

        Vector3 spawnPos = new Vector3(spawnPosX, spawnPosY, spawnPosZ);

        GameObject enemy = Instantiate(middlePursuitPre, spawnPos, Quaternion.identity);
        enemyList.Add(enemy);
    }

    protected virtual void SpawnBigPursuit()
    {
        float spawnPosX = Mathf.Clamp(Random.Range(player.transform.position.x - 50f, player.transform.position.x + 50f), -450f, 450f);
        float spawnPosY = Mathf.Clamp(Random.Range(player.transform.position.y - 50f, player.transform.position.y + 450f), -450f, 450f);
        float spawnPosZ = Mathf.Clamp(Random.Range(player.transform.position.z - 50f, player.transform.position.z + 450f), -450f, 450f);

        Vector3 spawnPos = new Vector3(spawnPosX, spawnPosY, spawnPosZ);

        GameObject enemy = Instantiate(bigPursuitPre, spawnPos, Quaternion.identity);
        enemyList.Add(enemy);
    }

    protected virtual void goNextLevel()
    {
        if (levelManager.curLevel == 5)
        {
            if (pursuitSpawnCount >= FixedPursuitSpawnCount + MovedPursuitSpawnCount && curPursuitSpawnCount <= 4)
            {
                levelManager.nextLevel();
                pursuitSpawnCount = 0;
            }
        }
        else
        {
            if (pursuitSpawnCount >= FixedPursuitSpawnCount + MovedPursuitSpawnCount && curPursuitSpawnCount <= 0)
            {
                levelManager.nextLevel();
                pursuitSpawnCount = 0;
            }
        }
    }


}
