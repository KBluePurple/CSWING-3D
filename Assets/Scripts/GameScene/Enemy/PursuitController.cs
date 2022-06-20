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

    private int pursuitLife = 100;

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
        lineRenderer.material.color = Color.red;
    }

    private void Start()
    {
        GameScene.PlayerManager.Instance.OnEnemyAdded.Invoke(transform);
    }

    void Update()
    {
        if (target != null)
        {
            if (this.gameObject.CompareTag("Pursuit"))
            {
                if (Vector3.Distance(target.transform.position, transform.position) <= 90f)
                {
                    lineRenderer.enabled = true;

                    curTime += Time.deltaTime;

                    transform.LookAt(target.transform);

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
            }
            else if (Vector3.Distance(target.transform.position, transform.position) <= Enemy.FindObjectOfType<Enemy>().detectionRange)
            {
                lineRenderer.enabled = true;

                curTime += Time.deltaTime;

                transform.LookAt(target.transform);

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

    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.gameObject.CompareTag("Bullet"))
    //     {
    //         pursuitLife -= playerAttack.bulletDamaged;
    //         Debug.Log("Pursuit ����������");
    //         if (pursuitLife <= 0)
    //         {
    //             PursuitDead();
    //         }
    //     }
    // }

    public void Damaged(int damage)
    {
        pursuitLife -= damage;
        Debug.Log("damaged");

        if (pursuitLife <= 0)
        {
            PursuitDead();
        }
    }

    public void PursuitDead()
    {
        Destroy(gameObject);
        PlayerManager.Instance.OnEnemyRemoved.Invoke(transform);
        // survivorModeManager.curPursuitSpawnCount--;
        ItemManager.Instance.SpawnItem(ItemType.CORE, transform.position);
        SoundManager.Instance.PlaySound("Heavy Object Impact 4");
        GameScene.GameManager.Instance.AddScore(100);
        Debug.Log("Pursuit ���");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            LockOn.Instance.SetIsLockOn(false);
            Debug.Log("Enemy 충돌");
            int damage = (int)(other.GetComponent<GameScene.PlayerMove>().Speed * 0.6f);
            if (pursuitLife < damage)
            {
                Damaged(pursuitLife);
            }
            else
            {
                Damaged(damage);
                other.transform.Translate((Vector3.forward * -1 * damage).normalized);
            }

            GameScene.PlayerManager.Instance.Damaged(damage);
        }
    }
}
