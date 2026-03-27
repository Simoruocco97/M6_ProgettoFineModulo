using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Pools")]
    [SerializeField] private EnemyPoolSystem[] enemyPools;

    [Header("Spawn Infos")]
    [SerializeField] private float spawnTimer = 8f;
    [SerializeField] private Transform[] spawnPoint;
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

    public float GetSpawnTime() => spawnTimer;

    public void SetSpawnTime(float newTimer)
    {
        spawnTimer = newTimer;
        timer = Mathf.Min(timer, newTimer);
    }

    private void SpawnEnemy()
    {
        if (enemyPools.Length == 0 || spawnPoint.Length == 0)
            return;

        int randomEnemy = Random.Range(0, enemyPools.Length);
        int randomSpawner = Random.Range(0, spawnPoint.Length);
        enemyPools[randomEnemy].SpawnEnemy(spawnPoint[randomSpawner].position);
    }
}