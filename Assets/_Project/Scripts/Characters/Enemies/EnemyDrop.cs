using UnityEngine;

public class EnemyDrop : MonoBehaviour
{
    [SerializeField] private GameObject coin;
    [SerializeField] private int dropChance = 50;
    [SerializeField] private float dropCircle = 0.5f;

    private void Awake()
    {
        if (coin == null)
            Debug.LogWarning($"Nessun gameobject assegnato al drop di {gameObject.name}");
    }

    private bool HasDropped()
    {
        return Random.Range(0, 100) < dropChance;
    }
   
    public void TryDrop()
    {
        if (HasDropped())
        {
            Vector3 randomOffset = Random.insideUnitCircle * dropCircle;
            randomOffset.z = 0;
            Vector3 spawnPos = transform.position + randomOffset;

            Instantiate(coin, spawnPos, Quaternion.identity);

            if (AudioManager.Instance != null)
                AudioManager.Instance.PlaySFXSound("CoinDrop");
        }
    }
}