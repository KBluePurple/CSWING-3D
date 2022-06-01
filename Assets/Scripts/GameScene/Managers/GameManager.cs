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
        private float spawnDelay = 10f;
        private float curDelay = 0f;

        void Start()
        {
            MouseManager.Show(false);
            MouseManager.Lock(true);
        }

        private void Update()
        {
            curDelay += Time.deltaTime;

            if(curDelay >= spawnDelay && curPursuitSpawnCount < maxPursuitSpawnCount)
            {
                SpawnPursuit();
                curDelay = 0f;
                Debug.Log("¼ÒÈ¯");
                curPursuitSpawnCount++;
            }
        }

        void SpawnPursuit()
        {
            float spawnPosX = Random.Range(-450f, 450f);
            float spawnPosY = Random.Range(-450f, 450f);
            float spawnPosZ = Random.Range(-450f, 450f);

            Vector3 spawnPos = new Vector3(spawnPosX, spawnPosY, spawnPosZ);

            Instantiate(pursuitPre, spawnPos, Quaternion.identity);
        }

    }
}