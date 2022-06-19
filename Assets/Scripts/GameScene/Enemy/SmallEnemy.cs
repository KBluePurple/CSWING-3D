using System.Reflection.Emit;
using UnityEngine;

public class SmallEnemy : Enemy
{
    [Header("Parant")]
    [SerializeField] Transform parant;
    protected override void OnDetected()
    {
        targetPosition = target.position;
    }

    protected override void OnUnDetected()
    {
        StartCoroutine(SetRandomReconnaissancePosition());
        targetPosition = parant.position;
    }

    protected override void Dead()
    {
        base.Dead();
        SoundManager.Instance.PlaySound("Heavy Object Impact 4");
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
        //OnCTriggerEnter(other);
    }
}