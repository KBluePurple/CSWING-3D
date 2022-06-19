using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private float maxDistance = 300f;
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
    [SerializeField] Material bulletMaterial;

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
                bullet.GetComponent<NormalBullet>()
                    .SetDamage(15)
                    .SetSpeed(100 + GameScene.PlayerMove.Instance.Speed)
                    .SetDistance(maxDistance)
                    .SetTargetPos(transform.position + transform.forward * maxDistance)
                    .SetTargetTag("Enemy")
                    .Fire(bulletPos);
                SoundManager.Instance.PlaySound("Hand Gun 1", SoundType.SE);
                break;
            case WeaponPart.L_01:
                bullet = Instantiate(L_01_bulletPre, bulletPos.position, bulletPos.rotation);
                bullet.GetComponent<LaserBullet>()
                    .SetDamage(50)
                    .SetLifeTime(0.4f)
                    .SetDistance(maxDistance)
                    .SetTargetPos(transform.position + transform.forward * maxDistance)
                    .SetTargetTag("Enemy")
                    .Fire(bulletPos);
                shotDelay = 3f;
                SoundManager.Instance.PlaySound("laser_01");
                break;
            case WeaponPart.M_01:
                bullet = Instantiate(M_01_bulletPre, bulletPos.position, bulletPos.rotation);
                bullet.GetComponent<MissileBullet>()
                    .SetDamage(10)
                    .SetSpeed(50 + GameScene.PlayerMove.Instance.Speed)
                    .SetLifeTime(4f)
                    .SetTarget(FindEnemy())
                    .SetTargetTag("Enemy")
                    .Fire(bulletPos);
                SoundManager.Instance.PlaySound("Flare gun 5-2");
                break;
            default:
                break;
        }
        bullet.GetComponentsInChildren<Renderer>().ToList().ForEach(x => x.material = bulletMaterial);

        curDelay = shotDelay;
        // GameObject bullet = Instantiate(bulletPre, bulletPos);
        // SoundManager.Instance.PlaySound("Hand Gun 1");
        // bullet.transform.SetParent(null);
    }

    private Transform FindEnemy()
    {
        List<GameObject> enemiesList = new List<GameObject>();
        foreach (var enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            enemiesList.Add(enemy);
        }
        foreach (var enemy in GameObject.FindGameObjectsWithTag("Pursuit"))
        {
            enemiesList.Add(enemy);
        }

        foreach (var enemy in enemiesList)
        {
            if (Vector3.Distance(enemy.transform.position, transform.position) < maxDistance)
            {
                return enemy.transform;
            }
        }

        RaycastHit hit;
        if (Physics.Raycast(this.transform.Find("RayCastPosition").position, this.transform.forward, out hit, Mathf.Infinity))
        {
            Debug.Log("RayCastHit : " + hit.transform);
            return hit.transform;
        }
        return null;
    }
}
