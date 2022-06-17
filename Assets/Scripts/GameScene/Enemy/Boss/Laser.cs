using System;
using GameScene;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] Transform parent;
    [SerializeField] Transform target;
    [SerializeField] Transform laser;
    private float time = 1f;
    private int damage = 10;

    private void Start()
    {
        
    }

    private void Update()
    {
        float distance = Vector3.Distance(parent.position, target.position);
        laser.LookAt(target);
        laser.transform.position = Vector3.Lerp(parent.position, target.position, 0.5f);
        laser.transform.localScale = new Vector3(laser.transform.localScale.x, laser.transform.localScale.y, distance);

        time -= UnityEngine.Time.deltaTime;

        if (time <= 0)
        {
            Destroy(gameObject);
        }
    }

    public Laser SetTime(float time)
    {
        this.time = time;
        return this;
    }

    public Laser SetTarget(Transform target)
    {
        this.target = target;
        return this;
    }

    public Laser SetParent(Transform transform)
    {
        this.parent = transform;
        return this;
    }

    public Laser SetDamage(int damage)
    {
        this.damage = damage;
        return this;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerManager.Instance.Damaged(damage);
        }
    }
}
