using System.Collections;
using UnityEngine;

public class PlayerDamageHandler : MonoBehaviour
{
    [SerializeField] private GameObject gameoverUI;
    [SerializeField] private float deathDelay = 3f;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Collider2D col;

    private void Awake()
    {
        if (playerController == null)
            playerController = GetComponent<PlayerController>();

        if (col == null)
            col = GetComponent<Collider2D>();
    }

    public void HandleDamage()
    {
        if (AudioManager.Instance != null)
            AudioManager.Instance.PlaySFXSound("PlayerDamage");
    }

    public void HandleDeath()
    {
        if (AudioManager.Instance != null)
            AudioManager.Instance.PlaySFXSound("GameoverSound");

        DisablePlayer();

        StartCoroutine(DeathSequence());
    }

    private IEnumerator DeathSequence()
    {
        yield return new WaitForSecondsRealtime(deathDelay);
        ShowGameoverUI();
    }

    private void ShowGameoverUI()
    {
        if (gameoverUI != null)
            gameoverUI.SetActive(true);

        Time.timeScale = 0f;
    }

    private void DisablePlayer()
    {
        if (playerController == null || col == null)
            return;

        playerController.enabled = false;
        col.enabled = false;
    }
}