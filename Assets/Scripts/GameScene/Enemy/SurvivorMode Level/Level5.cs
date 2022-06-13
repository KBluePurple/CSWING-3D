using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level5 : MonoBehaviour
{
    [SerializeField]
    private int subBoss = 1;
    [SerializeField]
    private int subBossHP = 150;

    [SerializeField]
    private GameObject subBossPre;

    private void SpawnMovedPursuit()
    {
        Vector3 spawnPos = subBossPre.transform.position;

        Instantiate(subBossPre, spawnPos, Quaternion.identity);
    }
}
