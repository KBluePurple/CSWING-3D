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

    [SerializeField] Transform target;
    [SerializeField] float ditectionRange = 30f;
    [SerializeField] float maxHp = 500f;
    [SerializeField] float hp = 500f;
    [SerializeField] float speed = 10f;

    private State currentState = State.Patrol;

    private bool isDetecting = false;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red; // 감지 범위
        Gizmos.DrawWireSphere(transform.position, ditectionRange);
        Gizmos.color = Color.cyan; // 순찰 경로
        Gizmos.DrawLine(transform.position, target.position);
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
        // TODO : 플레이어 주변을 돌면서 소형 적을 소환한다.
    }

    private void AttackType4()
    {
        // TODO : 정지 후 강한 공격을 한다.
    }

    private void Dead()
    {
        // TODO : 사망 처리
    }

    private void Boundary()
    {
        // TODO : 맵 중앙 돌기
    }

    private void Patrol()
    {
        // TODO : 순찰
    }
}
