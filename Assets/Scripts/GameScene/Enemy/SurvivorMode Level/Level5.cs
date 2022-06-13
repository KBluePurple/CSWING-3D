using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level5 : MonoBehaviour
{
    [SerializeField]
    private int subBoss = 1;

    [SerializeField]
    private GameObject subBossPre;

    private void SpawnFixedPursuit()
    {
        Vector3 spawnPos = subBossPre.transform.position;

        Instantiate(subBossPre, spawnPos, Quaternion.identity);
    }
}
