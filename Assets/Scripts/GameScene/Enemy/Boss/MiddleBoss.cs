using System.Collections;
using UnityEngine;

public class MiddleBoss : Enemy
{
    [SerializeField] float fireRange = 30f;
    [SerializeField] GameObject laserPrefab;
    private bool isCharging = false;

    protected override void OnDrawGizmosSelected()
    {
        base.OnDrawGizmosSelected();
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, fireRange);
    }

    protected override void OnDetected()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance < fireRange)
        {
            if (!isCharging)
            {
                StartCoroutine(FireLaser());
            }
            targetPosition = transform.position;
        }
        else
        {
            targetPosition = target.position;
        }
        transform.LookAt(target);
    }

    private IEnumerator FireLaser()
    {
        if (isCharging)
        {
            yield break;
        }

        isCharging = true;
        yield return new WaitForSeconds(3f);
        GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);
        laser.GetComponent<Laser>()
            .SetTarget(target)
            .SetTime(1f)
            .SetParent(transform);
        // TODO : 체력 비례 시간 조절
        isCharging = false;
    }
}
