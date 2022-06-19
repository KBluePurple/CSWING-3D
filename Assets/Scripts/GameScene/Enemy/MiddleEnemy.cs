using UnityEngine;

public enum MiddlePattern
{
    RoundPlayer,
    DashToPlayer
}

public class MiddleEnemy : Enemy
{
    [SerializeField] MiddlePattern pattern;

    protected override void Start()
    {
        base.Start();
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

    protected override void Dead()
    {
        base.Dead();
        SoundManager.Instance.PlaySound("Railgun - Shot 6");
    }
}