using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameScene;


public class PursuitController : MonoBehaviour
{
    private GameObject target;
    [SerializeField]
    private GameObject pursuitBulletPrefab;
    private Transform pursuitBulletPos;

    private int pursuitLife = 10;

    private float curTime = 0f;
    private float shotDelay = 2f;

    private LineRenderer lineRenderer = null;
    private GameManager gameManager = null;
    private PlayerAttack playerAttack = null;
    private SurvivorModeManager survivorModeManager = null;

    private void Awake()
    {
        target = GameObject.Find("Player");
        gameManager = FindObjectOfType<GameManager>();
        playerAttack = FindObjectOfType<PlayerAttack>();
        survivorModeManager = FindObjectOfType<SurvivorModeManager>();
        pursuitBulletPos = transform.GetChild(0);

        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.material.color = Color.white;
    }

    void Update()
    {
        if (target != null)
        {
            if (Vector3.Distance(target.transform.position, transform.position) <= 10f)
            {
                lineRenderer.enabled = true;

                curTime += Time.deltaTime;

                // transform.LookAt(target.transform);

                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, target.transform.position);

                if (curTime >= shotDelay - 0.2f)
                {
                    lineRenderer.material.color = Color.red;
                }

                if (curTime >= shotDelay)
                {
                    AttackTarget();
                    curTime = 0f;
                    lineRenderer.material.color = Color.white;
                }
            }
            else
            {
                lineRenderer.enabled = false;
                target = GameObject.Find("Player");
            }
        }
    }

    void AttackTarget()
    {
        GameObject pursuitBullet = Instantiate(pursuitBulletPrefab, pursuitBulletPos);
        pursuitBullet.transform.SetParent(null);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            pursuitLife -= playerAttack.bulletDamaged;
            Debug.Log("Pursuit 데미지입음");
            if (pursuitLife <= 0)
            {
                PursuitDead();
            }
        }
    }

    public void PursuitDead()
    {
        Destroy(gameObject);
        // survivorModeManager.curPursuitSpawnCount--;
        ItemManager.Instance.SpawnItem(ItemType.CORE, transform.position);
        Debug.Log("Pursuit 사망");
    }
}
