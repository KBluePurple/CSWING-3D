using UnityEngine;

public enum MiddlePattern
{
    RoundPlayer,
    DashToPlayer
}

public class MiddleEnemy : Enemy
{
    [SerializeField] MiddlePattern pattern;

    private void Start()
    {
        if (Random.Range(0, 2) == 0)
        {
            pattern = MiddlePattern.RoundPlayer;
        }
        else
        {
            pattern = MiddlePattern.DashToPlayer;
        }
    }

    protected override void OnDetected()
    {
        if (pattern == MiddlePattern.RoundPlayer)
        {
            targetPosition = target.position;
        }
        else
        {
            targetPosition = target.position + Random.onUnitSphere * 10f;
        }
    }

    protected override void OnUnDetected()
    {
        StartCoroutine(SetRandomReconnaissancePosition());
    }

    private void OnTriggerEnter(Collider other)
    {
        //OnCTriggerEnter(other);
    }
}