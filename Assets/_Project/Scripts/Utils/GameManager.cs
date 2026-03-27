using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private PlayerInventory inventory;
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private ShootingSystem shooting;

    [Header("Settings")]
    [SerializeField] private int startDifficultyIndex = 5;
    [SerializeField] private float increaseMultiplier = 1.2f;

    private void Awake()
    {
        if (inventory == null)
            inventory = FindAnyObjectByType<PlayerInventory>();

        if (enemySpawner == null)
            enemySpawner = FindAnyObjectByType<EnemySpawner>();

        if (shooting == null)
            shooting = FindAnyObjectByType<ShootingSystem>();
    }

    public void DifficultyChange()
    {
        if (inventory == null || shooting == null || enemySpawner == null)
            return;

        int coins = inventory.GetCoin();

        if (coins >= startDifficultyIndex)
        {
            Debug.Log("Difficolta' aumentata");

            float spawnTime = enemySpawner.GetSpawnTime();
            float fireRate = shooting.GetFireRate();

            enemySpawner.SetSpawnTime(spawnTime / increaseMultiplier);
            shooting.SetFireRate(fireRate / increaseMultiplier);
            startDifficultyIndex *= 2;
        }
    }
}