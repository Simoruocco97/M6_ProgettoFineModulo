using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private LifeController life;
    [SerializeField] private PlayerAnimationHandler animator;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 1f;

    private Vector2 dir;
    private float horizontal;
    private float vertical;

    private Vector2 Direction
    {
        get { return new Vector2(horizontal, vertical); }
    }

    private void Awake()
    {
        if (life == null)
            life = GetComponent<LifeController>();

        if (animator == null)
            animator = GetComponentInChildren<PlayerAnimationHandler>();

        if (rb == null)
            rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (life != null && !life.IsAlive())
        {
            horizontal = 0f;
            vertical = 0f;
            return;
        }

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        dir = Direction.normalized;
        animator.MovementAnimation(dir);
    }

    private void FixedUpdate()
    {
        if (life != null && !life.IsAlive())
        {
            return;
        }
        rb.MovePosition(rb.position + dir * (speed * Time.fixedDeltaTime));
    }
}
