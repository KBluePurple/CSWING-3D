using GameScene;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            SoundManager.Instance.PlaySound("Gun Sound 3");
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Enemy"))
        {

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        PlayerManager.Instance.Damaged(50);
    }
}
