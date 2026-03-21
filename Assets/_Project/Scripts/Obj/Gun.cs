using UnityEngine;
public class Gun : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    [SerializeField] private float fireRate = 1f;           //più alto il valore, più lenta spara l'arma
    [SerializeField] private GameObject[] bulletPrefabs;    //creo un array per poter sparare tipi di bullet diversi
    private float lastFireTime;
    private LifeController life;

    private void Awake()
    {
        life = GetComponent<LifeController>();

        lastFireTime = -fireRate;
    }

    private void Update()
    {
        if (life == null || !life.IsAlive()) 
            return;

        if (Time.time >= lastFireTime + fireRate)
        {
            Shoot();
            lastFireTime = Time.time;
        }
    }

    private void Shoot()
    {
        Transform target = FindNearestEnemy();
        if (target == null) return;

        int randomIndex = Random.Range(0, bulletPrefabs.Length);
        GameObject selectedBullet = bulletPrefabs[randomIndex];

        GameObject bulletObj = Instantiate(selectedBullet, transform.position, Quaternion.identity);

        if (AudioManager.Instance != null)
            AudioManager.Instance.PlaySFXSound("ShootSound");

        Bullet bullet = bulletObj.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.SetUp(target, damage);
        }
    }

    private Transform FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        Transform nearest = null;
        float nearestDist = float.MaxValue;

        foreach (GameObject enemy in enemies)
        {
            if (enemy == null) continue;

            if (enemy.TryGetComponent<LifeController>(out var life))
            {
                if (!life.IsAlive())
                    continue;
            }

            float dist = (enemy.transform.position - transform.position).sqrMagnitude;
            if (dist < nearestDist)
            {
                nearestDist = dist;
                nearest = enemy.transform;
            }
        }
        return nearest;
    }
}