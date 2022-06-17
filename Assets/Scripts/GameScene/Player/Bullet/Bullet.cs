using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float damage = 1f;
    [SerializeField] float speed = 10f;
    [SerializeField] float maxDistance = 30f;

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

    public void Fire(Transform from, Transform to)
    {
        var direction = to.position - from.position;
        direction.Normalize();
        transform.position = from.position;
        transform.rotation = Quaternion.LookRotation(direction);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, transform.parent.position) > maxDistance)
        {
            Destroy(gameObject);
        }
    }
}