using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance { get; private set; }
    private List<Transform> foundEnemies = new List<Transform>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void ListEnemy(Transform enemy) => foundEnemies.Add(enemy);
    public void UnlistEnemy(Transform enemy) => foundEnemies.Remove(enemy);
    public List<Transform> GetListedEnemies() => foundEnemies;
}
