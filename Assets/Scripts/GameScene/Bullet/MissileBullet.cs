using UnityEngine;

public class MissileBullet : Bullet
{
    [SerializeField] Transform target;
    [SerializeField] float speed;
    [SerializeField] float time;

    [SerializeField] bool builded = false;

    private void Update()
    {
        if (builded)
        {
            if (target != null)
            {
                Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * (speed * 0.1f));

                transform.Translate(Vector3.forward * Time.deltaTime * speed);
            }

            time -= Time.deltaTime;

            if (time <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    public MissileBullet SetDamage(float damage)
    {
        this.damage = damage;
        return this;
    }

    public MissileBullet SetLifeTime(float time)
    {
        this.time = time;
        return this;
    }

    public MissileBullet SetTarget(Transform target)
    {
        this.target = target;
        return this;
    }

    public MissileBullet SetSpeed(float speed)
    {
        this.speed = speed;
        return this;
    }

    public override void Fire(Transform bulletPos)
    {
        builded = true;
    }
}