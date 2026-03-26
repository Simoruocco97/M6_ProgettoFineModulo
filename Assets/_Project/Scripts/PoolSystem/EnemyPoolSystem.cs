using UnityEngine;

public class EnemyPoolSystem : PoolSystem<Enemy>
{
    protected override Enemy Create()
    {
        Enemy enemy = Instantiate(prefab);
        enemy.SetPool(pool);
        enemy.GetComponent<EnemyDamageHandler>().SetPool(pool);
        return enemy;
    }

    public void SpawnEnemy(Vector2 position)
    {
        Enemy enemy = pool.Get();
        enemy.transform.position = position;
        enemy.transform.rotation = Quaternion.identity;

        if (enemy.TryGetComponent<Collider2D>(out var collider))
            collider.enabled = true;

        if (enemy.TryGetComponent<LifeController>(out var life))
            life.ResetHealth();

        if (enemy.TryGetComponent<EnemiesAnimationHandler>(out var animation))
            animation.ResetAnimation();
    }
}