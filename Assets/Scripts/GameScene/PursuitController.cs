using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursuitController : MonoBehaviour
{
    private GameObject target;
    [SerializeField]
    private GameObject pursuitBulletPrefab;
    private Transform pursuitBulletPos;

    private float curTime = 0f;
    private float shotDelay = 2f;

    private void Awake()
    {
        target = GameObject.Find("Player");
        pursuitBulletPos = transform.GetChild(0);
    }

    void Update()
    {
        if (target != null)
        {
            if (Vector3.Distance(target.transform.position, transform.position) <= 30f)
            {
                curTime += Time.deltaTime;

                Vector3 dir = target.transform.position - transform.position;

                Quaternion rot = Quaternion.LookRotation(dir.normalized);

                transform.rotation = rot;

                if (curTime >= shotDelay)
                {
                    AttackTarget();
                    curTime = 0f;
                }
            }
            else
            {
                target = GameObject.Find("Player");
            }
        }
    }

    void AttackTarget()
    {
        GameObject pursuitBullet = Instantiate(pursuitBulletPrefab, pursuitBulletPos);
        pursuitBullet.transform.SetParent(null);
    }
}
