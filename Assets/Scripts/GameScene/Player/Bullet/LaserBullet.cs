using System;
using UnityEngine;

public class LaserBullet : MonoBehaviour
{
    [SerializeField] float damage = 1f;
    [SerializeField] float lifeTime = 1f;
    [SerializeField] float distance = 30f;
    [SerializeField] Transform laser;
    
    private Vector3 targetPos;

    public LaserBullet SetDamage(int bulletDamaged)
    {
        this.damage = bulletDamaged;
        return this;
    }

    public LaserBullet SetLifeTime(float lifeTime)
    {
        this.lifeTime = lifeTime;
        return this;
    }

    public LaserBullet SetDistance(float distance)
    {
        this.distance = distance;
        return this;
    }

    public void Fire(Transform from, Transform to)
    {
        float distance = Vector3.Distance(transform.position, targetPos);
        laser.LookAt(targetPos);
        laser.transform.position = Vector3.Lerp(transform.position, targetPos, 0.5f);
        laser.transform.localScale = new Vector3(laser.transform.localScale.x, laser.transform.localScale.y, distance);
    }

    private void Update()
    {
        lifeTime -= UnityEngine.Time.deltaTime;

        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}