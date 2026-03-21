using UnityEngine;

public class EnemyDamageHandler : MonoBehaviour
{
    [SerializeField] private LifeController life;
    [SerializeField] private Collider2D col;
    [SerializeField] private EnemyDrop drop;
    [SerializeField] private float deathDelay = 2f;

    private void Awake()
    {
        if (life == null)
            life = GetComponent<LifeController>();

        if (col == null)
            col = GetComponent<Collider2D>();
        
        if (drop == null)
            drop = GetComponent<EnemyDrop>();
    }

    public void HandleDamage()
    {
        if (AudioManager.Instance != null)
            AudioManager.Instance.PlaySFXSound("FruitImpact");
    }

    public void HandleDeath()
    {
        if (AudioManager.Instance != null)
            AudioManager.Instance.PlaySFXSound("EnemyDeath");

        drop.TryDrop();

        DisableEnemy();
        Destroy(gameObject, deathDelay);
    }

    private void DisableEnemy()
    {
        if (col == null)
            return;

        col.enabled = false;
    }
}