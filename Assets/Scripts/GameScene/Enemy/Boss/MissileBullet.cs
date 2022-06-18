using UnityEngine;

public class MissileBullet : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float speed;
    [SerializeField] float rotateSpeed = 10f;
    [SerializeField] float damage;

    private bool builded = false;

    private void Update()
    {
        if (builded)
        {
            // If there is a target
            if (target != null)
            {
                // change direction little by little toward the target.
                Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotateSpeed);
            }
        }
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

    public MissileBullet SetDamage(float damage)
    {
        this.damage = damage;
        return this;
    }

    public void Build()
    {
        builded = true;
    }
}