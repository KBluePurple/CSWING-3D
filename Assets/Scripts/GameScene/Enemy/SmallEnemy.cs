using System.Reflection.Emit;
using UnityEngine;

public class SmallEnemy : Enemy
{
    [Header("Parant")]
    [SerializeField] Transform parant;
    private float baseSpeed = 10f;
    protected override void OnDetected()
    {
        targetPosition = target.position;
    }

    protected override void OnUnDetected()
    {
        StartCoroutine(SetRandomReconnaissancePosition());
        targetPosition = parant.position;
    }

    public SmallEnemy SetParant(Transform parant)
    {
        this.parant = parant;
        return this;
    }

    public SmallEnemy SetTarget(Transform target)
    {
        this.target = target;
        return this;
    }

    private void OnTriggerEnter(Collider other)
    {
        OnCTriggerEnter(other);
    }
}