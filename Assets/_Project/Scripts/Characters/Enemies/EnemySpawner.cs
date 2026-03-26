using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Pools")]
    [SerializeField] private EnemyPoolSystem[] enemyPools;

    [Header("Spawn Infos")]
    [SerializeField] private float spawnTimer = 10f;
    private float timer = 0f;

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0) 
        {
            SpawnEnemy();
            timer = spawnTimer;
        }
    }

    private void SpawnEnemy()
    {
        if (enemyPools.Length == 0)
            return;

        int randomIndex = Random.Range(0, enemyPools.Length);
        enemyPools[randomIndex].SpawnEnemy(transform.position);
    }
}