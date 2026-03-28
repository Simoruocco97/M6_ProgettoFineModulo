using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private PlayerAnimationHandler animator;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private LifeController life;
    [SerializeField] private Rigidbody2D rb;

    [Header("Movement Settings")]
    [SerializeField] private float speed = 1f;

    private void Awake()
    {
        if (inputManager == null)
            inputManager = GetComponent<InputManager>();

        if (life == null)
            life = GetComponent<LifeController>();

        if (animator == null)
            animator = GetComponentInChildren<PlayerAnimationHandler>();

        if (rb == null)
            rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (life != null && inputManager != null && !life.IsAlive())
        {
            if (inputManager.IsActive)
                inputManager.StopInput();

            return;
        }

        if (animator != null && inputManager != null)
            animator.MovementAnimation(inputManager.MovementSystem);
    }

    private void FixedUpdate()
    {
        if (life == null || inputManager == null || !life.IsAlive())
            return;

        rb.MovePosition(rb.position + inputManager.MovementSystem * (speed * Time.fixedDeltaTime));
    }
}
