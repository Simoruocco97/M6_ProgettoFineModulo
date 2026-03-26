using UnityEngine;

public class BulletPoolSystem : PoolSystem<Bullet>
{
    protected override Bullet Create()
    {
        Bullet bullet = Instantiate(prefab);
        bullet.SetPool(pool);
        return bullet;
    }

    public void SpawnBullet(Vector3 position, Transform target, int damage)
    {
        Bullet bullet = pool.Get();
        bullet.transform.position = position;
        bullet.transform.rotation = Quaternion.identity;
        bullet.SetUp(target, damage);
    }
}