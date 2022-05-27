using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private GameObject enemyBulletPrefab;

    void Update()
    {
        if(Vector3.Distance(target.transform.position, transform.position) <= 30f)
        {
            //Vector3 dir = target.transform.position - transform.position;

            //Quaternion rot = Quaternion.LookRotation(dir.normalized);

            //transform.rotation = rot;

            StartCoroutine(AttackTarget());
        }
    }

    IEnumerator AttackTarget()
    {
        GameObject bullet = Instantiate(enemyBulletPrefab);

        bullet.transform.Translate(transform.position);

        yield return new WaitForSeconds(0.5f);
    }
}
