using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Rigidbody2D rb;
    private ObjectPool<Bullet> pool;
    private Transform target;
    private bool isActive = false;

    [Header("Bullet Info")]
    [SerializeField] private float speed;
    [SerializeField] private int damage;
    [SerializeField] private float bulletLifeTime;
    private float bornTime;

    private void Awake()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Time.time > bornTime + bulletLifeTime)
            ReturnToPool();
    }

    private void FixedUpdate()
    {
        if (target == null)
        {
            ReturnToPool();
            return;
        }

        Vector2 dir = ((Vector2)target.position - rb.position).normalized;
        rb.velocity = dir * speed;
    }

    private void OnEnable()
    {
        isActive = true;
        bornTime = Time.time;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<LifeController>(out var life))
            life.TakeDamage(damage);

        ReturnToPool();
    }

    public void SetUp(Transform target, int damage)
    {
        this.target = target;
        this.damage = damage;
    }

    public void SetPool(ObjectPool<Bullet> pool)
    {
        this.pool = pool;
    }

    private void ReturnToPool()
    {
        if (!isActive)
            return;

        isActive = false;
        target = null;
        rb.velocity = Vector2.zero;

        if (pool != null)
            pool.Release(this);
        else
            Destroy(gameObject);
    }
}