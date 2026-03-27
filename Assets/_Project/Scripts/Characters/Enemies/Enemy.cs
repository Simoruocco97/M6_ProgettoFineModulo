using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private LifeController life;
    [SerializeField] private EnemiesAnimationHandler anim;
    [SerializeField] private Rigidbody2D rb;

    [Header("Player Infos")]
    [SerializeField] private Transform playerTransform;

    [SerializeField] private int enemyDmg = 1;
    [SerializeField] private float speed = 2f;

    private void Awake()
    {
        if (life == null)
            life = GetComponent<LifeController>();

        if (anim == null)
            anim = GetComponentInChildren<EnemiesAnimationHandler>();

        if (rb == null)
            rb = GetComponent<Rigidbody2D>();

        if (playerTransform == null)
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        if (playerTransform == null || !life.IsAlive())
            return;

        Vector2 direction = (playerTransform.position - transform.position).normalized;

        if (rb != null)
            rb.MovePosition(rb.position + direction * (speed * Time.fixedDeltaTime));

        if (anim != null)
            anim.MovementAnimation(direction);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;

        if (collision.gameObject.TryGetComponent<LifeController>(out var playerLife))
            playerLife.TakeDamage(enemyDmg);

        if (life != null)
            life.Suicide();
    }

    private void OnEnable()
    {
        if (EnemyManager.Instance != null)
            EnemyManager.Instance.ListEnemy(transform);
    }

    private void OnDisable()
    {
        if (EnemyManager.Instance != null)
            EnemyManager.Instance.UnlistEnemy(transform);
    }
}