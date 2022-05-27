using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursuitController : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private GameObject pursuitBulletPrefab;
    [SerializeField]
    private Transform bulletPos;

    private float curTime = 0f;
    private float shotDelay = 2f;

    private void Awake()
    {
        target = GameObject.Find("Player");
    }

    void Update()
    {
        if(Vector3.Distance(target.transform.position, transform.position) <= 30f)
        {
            curTime += Time.deltaTime;

            Vector3 dir = target.transform.position - transform.position;

            Quaternion rot = Quaternion.LookRotation(dir.normalized);

            transform.rotation = rot;

            if(curTime >= shotDelay)
            {
                AttackTarget();
                curTime = 0f;
            }

        }
    }

    void AttackTarget()
    {
        GameObject bullet = Instantiate(pursuitBulletPrefab, bulletPos);

        
    }
}
