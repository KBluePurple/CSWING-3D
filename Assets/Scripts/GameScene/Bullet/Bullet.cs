using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class Bullet : MonoBehaviour
{
    [SerializeField] protected string targetTag;
    [SerializeField] protected float damage;

    protected bool isBuilded = false;
    
    public Bullet SetTargetTag(string targetTag)
    {
        this.targetTag = targetTag;
        return this;
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        // TODO 데미지 받게 해줘잉
    }

    public abstract void Fire(Transform bulletPos);
}