using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameScene
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject pursuitPre;
        [SerializeField]
        private int maxPursuitSpawnCount = 5;

        private int curPursuitSpawnCount = 0;
        private float spawnDelay = 90f;
        private float curDelay = 0f;

        private int curFixedPursuitSpawnCount = 3;
        private int curMovedPursuitSpawnCount = 2;

        [SerializeField]
        private GameObject player;

        void Start()
        {
            MouseManager.Show(false);
            MouseManager.Lock(true);
        }

        private void Update()
        {
            curDelay += Time.deltaTime;

            SpawnPurusit();
        }


        void SpawnPurusit()
        {
            if (curPursuitSpawnCount == 0 || curDelay >= spawnDelay)
            {
                if (curPursuitSpawnCount <= curFixedPursuitSpawnCount)
                {
                    SpawnFixedPursuit();
                    curPursuitSpawnCount++;
                    curDelay = 0f;
                    Debug.Log("고정 적 생성");
                }
                else if (curPursuitSpawnCount > curFixedPursuitSpawnCount &&
                        curFixedPursuitSpawnCount + curMovedPursuitSpawnCount <= curPursuitSpawnCount)
                {
                    SpawnMovedPursuit();
                    curPursuitSpawnCount++;
                    curDelay = 0f;
                    Debug.Log("움직이는 적 생성");
                }
            }
        }
        void SpawnFixedPursuit()
        {
            float spawnPosX = Random.Range(player.transform.position.x + 50f, player.transform.position.x + 450f);
            float spawnPosY = Random.Range(player.transform.position.y + 50f, player.transform.position.y + 450f);
            float spawnPosZ = Random.Range(player.transform.position.z + 50f, player.transform.position.z + 450f);

            Vector3 spawnPos = new Vector3(spawnPosX, spawnPosY, spawnPosZ);

            Instantiate(pursuitPre, spawnPos, Quaternion.identity);
        }

        void SpawnMovedPursuit()
        {
            float spawnPosX = Random.Range(player.transform.position.x - 50f, player.transform.position.x + 50f);
            float spawnPosY = Random.Range(player.transform.position.y - 50f, player.transform.position.y + 450f);
            float spawnPosZ = Random.Range(player.transform.position.z - 50f, player.transform.position.z + 450f);

            Vector3 spawnPos = new Vector3(spawnPosX, spawnPosY, spawnPosZ);

            Instantiate(pursuitPre, spawnPos, Quaternion.identity);
        }

    }
}