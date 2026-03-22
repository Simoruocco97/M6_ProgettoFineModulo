using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private PlayerInventory inventory;

    private void Awake()
    {
        if (inventory == null)
            inventory = GetComponent<PlayerInventory>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inventory = collision.GetComponent<PlayerInventory>();
            inventory.AddCoin(1);

            if (AudioManager.Instance != null)
                AudioManager.Instance.PlaySFXSound("CoinPickup");

            Destroy(gameObject);
        }
    }
}