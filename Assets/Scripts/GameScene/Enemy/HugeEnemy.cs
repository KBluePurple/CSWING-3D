using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HugeEnemy : MonoBehaviour
{
    public enum State
    {
        Patrol,
        Boundary,
        AttackType1,
        AttackType2,
        AttackType3,
        AttackType4,
        Dead
    }

    Transform target;
    [SerializeField] float ditectionRange = 30f;
    [SerializeField] float maxHp = 500f;
    [SerializeField] float hp = 500f;
    [SerializeField] float speed = 10f;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] GameObject smallEnemyPrefab;

    private State currentState = State.Patrol;

    private bool isDetecting = false;
    private bool isFreezed = false;
    private float delay = 0f;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red; // 감지 범위
        Gizmos.DrawWireSphere(transform.position, ditectionRange);
        Gizmos.color = Color.cyan; // 순찰 경로
        Gizmos.DrawLine(transform.position, target.position);
    }

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        if (distance <= ditectionRange) // 적이 발견되었을 때
        {
            if (!isDetecting)
            {
                isDetecting = true;
                StartCoroutine(OnDetected());
            }
        }
        else // 적이 없을 때
        {
            if (isDetecting)
            {
                isDetecting = false;
                StopCoroutine(OnUndetected());
            }
        }

        if (isFreezed)
        {
            return;
        }

        switch (currentState)
        {
            case State.Patrol:
                Patrol();
                break;
            case State.Boundary:
                Boundary();
                break;
            case State.AttackType1:
                AttackType1();
                break;
            case State.AttackType2:
                AttackType2();
                break;
            case State.AttackType3:
                AttackType3();
                break;
            case State.AttackType4:
                AttackType4();
                break;
            case State.Dead:
                Dead();
                break;
        }
    }

    IEnumerator OnDetected()
    {
        // 적이 발견되었을 때 4개 공격 중 하나 랜덤 실행
        int behaviorType = Random.Range(0, 5);
        currentState = (State)(behaviorType + 1);

        yield return null;
    }

    IEnumerator OnUndetected()
    {
        if (hp > maxHp / 2)
        {
            currentState = State.Boundary;
        }
        else
        {
            currentState = State.Patrol;
        }
        yield return null;
    }

    private void AttackType1()
    {
        Collider[] detections = Physics.OverlapSphere(transform.position, 100f);
        Enemy[] purshits = detections.Select(x => x.GetComponent<Enemy>()).Where(x => x != null).ToArray();
        for (int i = 0; i < purshits.Length; i++)
        {
            purshits[i].ComeHere(transform.position);
        }
    }

    private void AttackType2()
    {
        transform.LookAt(target.position);
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void AttackType3()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        if (delay > 0)
        {
            delay -= Time.deltaTime;
            return;
        }

        delay = 1f;
        GameObject smallEnemy = Instantiate(smallEnemyPrefab, transform.position, Quaternion.identity);
        smallEnemy.GetComponent<SmallEnemy>()
            .SetParant(transform)
            .SetTarget(target);
        transform.LookAt(target.position + Random.onUnitSphere * 10f);
    }

    private void AttackType4()
    {
        StartCoroutine(AttackType4_Coroutine());
    }

    IEnumerator AttackType4_Coroutine()
    {
        // 차징 후 강한 공격 발사
        isFreezed = true;
        yield return new WaitForSeconds(1f);
        GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);
        laser.GetComponent<Laser>()
            .SetParent(transform)
            .SetTarget(target)
            .SetTime(1f)
            .SetDamage(100);
        yield return new WaitForSeconds(1f);
        isFreezed = false;

        yield return null;
    }

    private void Dead()
    {
        // TODO : 사망 처리
    }

    private void Boundary()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        if (delay > 0)
        {
            delay -= Time.deltaTime;
            return;
        }

        delay = 1f;

        transform.LookAt(Random.onUnitSphere * 10f);
    }

    private void Patrol()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        if (delay > 0)
        {
            delay -= Time.deltaTime;
            return;
        }

        delay = 10f;

        transform.LookAt(Vector3.zero);
    }
}
