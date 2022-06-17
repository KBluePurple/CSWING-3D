using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level10 : MonoBehaviour
{
    [SerializeField]
    private GameObject boss = null;
    [SerializeField]
    private GameObject spawnPos = null;

    void OnEnable()
    {
        Instantiate(boss, spawnPos.transform);
    }
}
