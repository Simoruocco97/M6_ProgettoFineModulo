using System.Collections.Generic;
using UnityEngine;

public class ShootingSystem : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private LifeController life;

    [Header("Pools")]
    [SerializeField] private BulletPoolSystem[] bulletPools;

    [Header("Shooting Info")]
    [SerializeField] private float shootingRange = 10f;
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private int damage = 1;
    private float lastFireTime;

    private void Awake()
    {
        if (life == null)
            life = GetComponent<LifeController>();

        lastFireTime = -fireRate;
    }

    private void Update()
    {
        if (life == null || !life.IsAlive())
            return;

        Shoot();
    }

    public float GetFireRate() => fireRate;

    public void SetFireRate(float newFireRate)
    {
        fireRate = Mathf.Min(fireRate, newFireRate);
    }

    private void Shoot()
    {
        if (bulletPools.Length == 0)
            return;

        if (Time.time >= lastFireTime + fireRate)
        {
            Transform target = FindNearestEnemy();
            if (target == null) return;

            int randomIndex = Random.Range(0, bulletPools.Length);
            bulletPools[randomIndex].SpawnBullet(transform.position, target, damage);

            if (AudioManager.Instance != null)
                AudioManager.Instance.PlaySFXSound("ShootSound");

            lastFireTime = Time.time;
        }
    }

    private Transform FindNearestEnemy()
    {
        Transform nearest = null;
        float nearestDist = float.MaxValue;

        if (EnemyManager.Instance == null)
            return nearest;

        foreach (Transform enemy in EnemyManager.Instance.GetListedEnemies())
        {
            if (enemy == null) continue;

            if (enemy.TryGetComponent<LifeController>(out var enemyLife))
            {
                if (!enemyLife.IsAlive())
                    continue;
            }

            float dist = (enemy.position - transform.position).sqrMagnitude;
            if (dist > shootingRange * shootingRange)
                continue;

            if (dist < nearestDist)
            {
                nearestDist = dist;
                nearest = enemy;
            }
        }
        return nearest;
    }
}