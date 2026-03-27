using UnityEngine;
using UnityEngine.Events;

public class PickUp : MonoBehaviour
{
    [SerializeField] private PlayerInventory inventory;
    [SerializeField] private GameManager gameManager;

    private void Awake()
    {
        if (inventory == null)
            inventory = GetComponent<PlayerInventory>();

        if (gameManager == null)
            gameManager = FindAnyObjectByType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inventory = collision.GetComponent<PlayerInventory>();
            inventory.AddCoin(1);
            gameManager?.DifficultyChange();

            if (AudioManager.Instance != null)
                AudioManager.Instance.PlaySFXSound("CoinPickup");

            Destroy(gameObject);
        }
    }
}