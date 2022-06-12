using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] protected Transform target;
    [SerializeField] protected Vector3 reconnaissancePosition;
    [SerializeField] protected float speed = 10f;
    [SerializeField] protected float health = 100f;
    [SerializeField] protected float damage = 10f;
    [SerializeField] protected float reconnaissanceRange = 10f;
    [SerializeField] protected float detectionRange = 10f;

    protected Vector3 targetPosition = Vector3.zero;
    protected bool isDetected = false;
    private bool reconnaissanceCoolingDown = false;

    protected virtual void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(targetPosition, 0.1f);
        Gizmos.color = Color.blue;
        if (reconnaissancePosition != Vector3.zero)
        {
            Gizmos.DrawWireSphere(reconnaissancePosition, reconnaissanceRange);
        }
        else
        {
            Gizmos.DrawWireSphere(transform.position, reconnaissanceRange);
        }
    }

    protected virtual void Awake()
    {
        reconnaissancePosition = transform.position;
    }

    protected virtual void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance < detectionRange && distance > 0.1f)
        {
            OnDetected();
        }
        else
        {
            OnUnDetected();
        }
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        transform.LookAt(targetPosition);
    }

    protected virtual void OnDetected()
    {
    }

    protected virtual void OnUnDetected()
    {
    }

    protected virtual IEnumerator SetRandomReconnaissancePosition()
    {
        if (!reconnaissanceCoolingDown)
        {
            reconnaissanceCoolingDown = true;
            yield return new WaitForSeconds(5f);
            targetPosition = Random.onUnitSphere * reconnaissanceRange + reconnaissancePosition;
            reconnaissanceCoolingDown = false;
        }
    }
}
