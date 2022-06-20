using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursuitBulletMove : MonoBehaviour
{
    [SerializeField]
    private float bulletSpeed = 5f;
    [SerializeField] int damage = 1;

    private void Start()
    {
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        transform.Translate((Vector3.forward * bulletSpeed * Time.deltaTime).normalized);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameScene.PlayerManager.Instance.Damaged(30);
        }
    }
}
