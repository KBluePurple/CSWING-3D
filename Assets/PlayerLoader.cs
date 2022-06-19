using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoader : MonoBehaviour
{
    [SerializeField] List<GameObject> BodyPrefabs = new List<GameObject>();
    [SerializeField] Transform bodyTransform;

    private void Start()
    {
        // for (int i = 0; i < bodyTransform.childCount; i++)
        // {
        //     Destroy(bodyTransform.GetChild(i).gameObject);
        // }
        Destroy(bodyTransform.GetChild(0).gameObject);
        var body = Instantiate(BodyPrefabs[(int)SaveManager.Instance.Parts.Body - 1], bodyTransform);
    }
}
