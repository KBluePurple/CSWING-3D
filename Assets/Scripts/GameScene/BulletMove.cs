using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField]
    private float bulletSpeed = 5f;

    void Update()
    {
        transform.Translate((Vector3.up * bulletSpeed * Time.deltaTime).normalized);
    }
}
