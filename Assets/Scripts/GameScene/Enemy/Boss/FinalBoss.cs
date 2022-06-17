using UnityEngine;

public class FinalBoss : MonoBehaviour
{
    public enum State
    {
        Dash,
        Missile,
        Mixing,
        Invincibility
    }

    [SerializeField] float hp = 1000;
    [SerializeField] float speed = 10;

    [SerializeField] GameObject missilePrefab;
    [SerializeField] float missileSpeed = 10;

    private State state = State.Dash;
    private int missileCount = 5;

    private void Start()
    {
        
    }

    private void Update()
    {
        switch (state)
        {
            case State.Dash:
                Dash();
                break;
            case State.Missile:
                Missile();
                break;
            case State.Invincibility:
                Invincibility();
                break;
            case State.Mixing:
                Mixing();
                break;
        }
    }

    private void ChangeState()
    {
        state = (State)Random.Range(0, 3);

        switch (state)
        {
            case State.Dash:
                break;
            case State.Missile:
                missileCount++;
                break;
            case State.Invincibility:
                break;
            case State.Mixing:
                break;
        }
    }

    private void Mixing() // TODO 나중에 알려주겠지
    {
        Debug.LogError("구현 안됨");
    }

    private void Invincibility() // TODO 나중에 알려주겠지
    {
        Debug.LogError("구현 안됨");
    }

    private void Missile()
    {
        // TODO 제자리에 멈춰서 추적하는 미사일 n발 발사, 미사일 파괴 가능
        Debug.LogError("구현 안됨");
    }

    private void Dash()
    {
        Debug.LogError("구현 안됨");
    }

    public void OnDamage(float damage)
    {
        if (state == State.Invincibility)
            return;
        hp -= damage;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}