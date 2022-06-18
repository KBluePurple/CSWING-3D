using UnityEngine;

public class NormalBullet : Bullet
{
    [SerializeField] float speed = 10f;
    [SerializeField] float maxDistance = 30f;

    private Vector3 targetPos;
    private Vector3 startPos;

    public NormalBullet SetDamage(float damage)
    {
        this.damage = damage;
        return this;
    }

    public NormalBullet SetSpeed(float speed)
    {
        this.speed = speed;
        return this;
    }

    public NormalBullet SetDistance(float maxDistance)
    {
        this.maxDistance = maxDistance;
        return this;
    }

    public NormalBullet SetTargetPos(Vector3 targetPos)
    {
        this.targetPos = targetPos;
        return this;
    }

    public override void Fire(Transform from)
    {
        var direction = targetPos - from.position;
        direction.Normalize();
        transform.position = from.position;
        transform.rotation = Quaternion.LookRotation(direction);
        startPos = transform.position;
    }

    private void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        Debug.Log($"{Vector3.Distance(transform.position, startPos)} / {maxDistance}");
        if (Vector3.Distance(transform.position, startPos) > maxDistance)
        {
            Destroy(gameObject);
        }
    }
}