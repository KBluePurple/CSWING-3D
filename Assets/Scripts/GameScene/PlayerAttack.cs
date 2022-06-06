using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private float rayMaxDistance = 30f;
    [SerializeField]
    private Transform rayTransform;
    private RaycastHit rayHit;


    // Shot Bullet
    [SerializeField]
    private GameObject bulletPre;
    [SerializeField]
    private Transform bulletPos;

    private float shotDelay = 0.1f;
    private float curDelay = 0f;

    void Update()
    {
        curDelay += Time.deltaTime;

        Debug.DrawRay(rayTransform.position, (rayTransform.position - transform.position) * rayMaxDistance, Color.red);
        if (Physics.Raycast(rayTransform.position, (rayTransform.position - transform.position), out rayHit, rayMaxDistance))
        {
            Debug.Log("적 감지");
        }

        if (Input.GetMouseButton(0))
        {
            if(curDelay >= shotDelay)
            {
                Fire();
                curDelay = 0f;
            }
        }
    }

    void Fire()
    {
        GameObject bullet = Instantiate(bulletPre, bulletPos);
        Destroy(bullet, 3f);
    }
}
