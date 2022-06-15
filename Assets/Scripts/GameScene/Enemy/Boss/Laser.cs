using System;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] Transform parent;
    [SerializeField] Transform target;
    [SerializeField] Transform laser;
    public float Time = 1f;

    private void Start()
    {
        
    }

    private void Update()
    {
        float distance = Vector3.Distance(parent.position, target.position);
        laser.LookAt(target);
        laser.transform.position = Vector3.Lerp(parent.position, target.position, 0.5f);
        laser.transform.localScale = new Vector3(laser.transform.localScale.x, laser.transform.localScale.y, distance);

        Time -= UnityEngine.Time.deltaTime;

        if (Time <= 0)
        {
            Destroy(gameObject);
        }
    }

    public Laser SetTime(float time)
    {
        Time = time;
        return this;
    }

    public Laser SetTarget(Transform target)
    {
        this.target = target;
        return this;
    }

    public void SetParent(Transform transform)
    {
        this.parent = transform;
    }

    private void OnCollisionEnter(Collision other)
    {
        // TODO : 충돌 시 체력 깎음
    }
}