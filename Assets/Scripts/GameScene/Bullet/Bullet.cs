using System;
using UnityEngine;
using GameScene;

[RequireComponent(typeof(Collider))]
public abstract class Bullet : MonoBehaviour
{
    [SerializeField] protected string targetTag;
    [SerializeField] protected int damage;

    protected bool isBuilded = false;

    public Bullet SetTargetTag(string targetTag)
    {
        this.targetTag = targetTag;
        return this;
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            if (targetTag.CompareTo("Player") == 0)
            {
                PlayerManager.Instance.Damaged(damage);
            }
            else if (targetTag.CompareTo("Enemy") == 0)
            {
                var enemy = other.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.Damaged(damage);
                }
            }
        }
        else if (other.CompareTag("Pursuit"))
        {
            if (targetTag.CompareTo("Enemy") == 0)
            {
                var enemy = other.GetComponent<PursuitController>();
                if (enemy != null)
                {
                    enemy.Damaged(damage);
                }
            }
        }
        Destroy(gameObject);
    }

    public abstract void Fire(Transform bulletPos);
}