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
    public GameObject bulletPre { private set; get; }
    [SerializeField]
    private GameObject G_01_bulletPre;
    [SerializeField]
    private GameObject L_01_bulletPre;
    [SerializeField]
    private GameObject M_01_bulletPre;
    [SerializeField]
    private Transform bulletPos;
    [SerializeField]
    public int bulletDamaged { get; private set; } = 1;

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

        WeaponSet();

        if (Input.GetMouseButton(0))
        {
            if(curDelay >= shotDelay)
            {
                Fire();
                curDelay = 0f;
            }
        }
    }

    void WeaponSet()
    {
        switch (SaveManager.Instance.Parts.Weapon)
        {
            case WeaponPart.NONE:
                break;
            case WeaponPart.G_01:
                bulletPre = G_01_bulletPre;
                break;
            case WeaponPart.L_01:
                bulletPre = L_01_bulletPre;
                break;
            case WeaponPart.M_01:
                bulletPre = M_01_bulletPre;
                break;
        }
    }

    void Fire()
    {
        GameObject bullet = Instantiate(bulletPre, bulletPos);
        SoundManager.Instance.PlaySound("Hand Gun 1");
        bullet.transform.SetParent(null);
        Destroy(bullet, 3f);
    }
}
