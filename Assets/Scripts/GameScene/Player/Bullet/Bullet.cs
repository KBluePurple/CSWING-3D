using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float damage = 1f;
    [SerializeField] float speed = 10f;
    [SerializeField] float maxDistance = 30f;

    private Vector3 targetPos;
    private Vector3 startPos;

    public Bullet SetDamage(float damage)
    {
        this.damage = damage;
        return this;
    }

    public Bullet SetSpeed(float speed)
    {
        this.speed = speed;
        return this;
    }

    public Bullet SetDistance(float maxDistance)
    {
        this.maxDistance = maxDistance;
        return this;
    }

    public Bullet SetTargetPos(Vector3 targetPos)
    {
        this.targetPos = targetPos;
        return this;
    }

    public void Fire(Transform from)
    {
        var direction = targetPos - from.position;
        direction.Normalize();
        transform.position = from.position;
        transform.rotation = Quaternion.LookRotation(direction);
        startPos = transform.position;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, startPos) > maxDistance)
        {
            Destroy(gameObject);
        }
    }
}