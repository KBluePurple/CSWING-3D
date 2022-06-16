using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : MonoBehaviour
{
    public enum State
    {
        Patrol,
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
    }

    IEnumerator OnDetected()
    {
        int behaviorType = Random.Range(0, 5);
        currentState = (State)(behaviorType + 1);

        yield return null;
    }

    IEnumerator OnUndetected()
    {
        if (hp > maxHp / 2)
        {
            // TODO: 마지막으로 인식한 적 위치로 이동
        }
        else
        {
            currentState = State.Patrol;
        }
        yield return null;
    }
}
