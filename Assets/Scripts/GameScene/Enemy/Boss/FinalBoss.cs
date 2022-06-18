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
    [SerializeField] Transform target;

    private State state = State.Dash;
    private int missileCount = 5;
    private bool isInvincied = false;

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
        state = isInvincied ? (State)Random.Range(0, 3) : (State)Random.Range(0, 4);

        switch (state)
        {
            case State.Dash:
                break;
            case State.Missile:
                missileCount++;
                break;
            case State.Mixing:
                break;
            case State.Invincibility:
                break;
        }

        Debug.Log($"{this.GetType().Name} : {state}");
    }

    private void Mixing() // TODO 나중에 알려주겠지
    {
        Debug.LogError("구현 안됨");
    }

    private void Invincibility()
    {
        // TODO 가만히...
    }

    private void Missile()
    {
        for (int i = 0; i < missileCount; i++)
        {
            GameObject missile = Instantiate(missilePrefab, transform.position, Quaternion.identity);
            missile.transform.Rotate(0, 0, Random.Range(0, 360));
            missile.GetComponent<MissileBullet>()
                .SetTarget(target)
                .SetSpeed(missileSpeed)
                .SetDamage(1)
                .SetTargetTag("Player")
                .Fire(transform);
        }
    }

    private void Dash()
    {
        transform.LookAt(target);
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    public void OnDamage(float damage)
    {
        if (state == State.Invincibility)
            return;

        damage *= 0.8f;

        hp -= damage;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (state == State.Dash)
        {
            if (other.gameObject.tag == "Player")
            {
                GameScene.PlayerManager.Instance.Damaged(50);
            }

            other.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * 10, ForceMode.Impulse);
        }
    }
}
