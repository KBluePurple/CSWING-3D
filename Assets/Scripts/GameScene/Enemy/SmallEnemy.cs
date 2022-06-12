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
}