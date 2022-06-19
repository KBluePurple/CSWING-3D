using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level5 : MonoBehaviour
{
    [SerializeField]
    private GameObject subBossPre;

    private void SpawnMovedPursuit()
    {
        Vector3 spawnPos = subBossPre.transform.position;

        Instantiate(subBossPre, spawnPos, Quaternion.identity);
    }
}
