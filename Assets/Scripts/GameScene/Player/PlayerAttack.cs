using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private float maxDistance = 30f;
    [SerializeField]
    private Transform rayTransform;
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

    private void Start()
    {
        WeaponSet();
    }

    void Update()
    {
        curDelay += Time.deltaTime;

        if (Input.GetMouseButton(0))
        {
            if (curDelay >= shotDelay)
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
                shotDelay = 0.1f;
                break;
            case WeaponPart.L_01:
                bulletPre = L_01_bulletPre;
                shotDelay = 0.3f;
                break;
            case WeaponPart.M_01:
                bulletPre = M_01_bulletPre;
                shotDelay = 0.75f;
                break;
        }
    }

    void Fire()
    {
        GameObject bullet = null;
        // Debug.DrawRay(transform.position, transform.forward * maxDistance, Color.white, 5f);
        switch (SaveManager.Instance.Parts.Weapon)
        {
            case WeaponPart.G_01:
                bullet = Instantiate(G_01_bulletPre, bulletPos.position, bulletPos.rotation);
                bullet.GetComponent<Bullet>()
                    .SetDamage(bulletDamaged)
                    .SetSpeed(10f)
                    .SetDistance(maxDistance)
                    .SetTargetPos(transform.position + transform.forward * maxDistance)
                    .Fire(bulletPos);
                break;
            case WeaponPart.L_01:
                bullet = Instantiate(L_01_bulletPre, bulletPos.position, bulletPos.rotation);
                bullet.GetComponent<LaserBullet>()
                    .SetDamage(bulletDamaged)
                    .SetLifeTime(2f)
                    .SetDistance(maxDistance)
                    .SetTargetPos(transform.position + transform.forward * maxDistance)
                    .Fire(bulletPos);
                shotDelay = 3f;
                break;
            case WeaponPart.M_01:
                bullet = Instantiate(M_01_bulletPre, bulletPos.position, bulletPos.rotation);
                bullet.GetComponent<Bullet>()
                    .SetDamage(bulletDamaged)
                    .SetSpeed(10f)
                    .SetDistance(maxDistance)
                    .SetTargetPos(transform.position + transform.forward * maxDistance)
                    .Fire(bulletPos);
                break;
            default:
                break;
        }

        curDelay = shotDelay;
        // GameObject bullet = Instantiate(bulletPre, bulletPos);
        // SoundManager.Instance.PlaySound("Hand Gun 1");
        // bullet.transform.SetParent(null);
    }
}
