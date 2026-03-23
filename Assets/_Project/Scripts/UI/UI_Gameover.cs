using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Gameover : UI_InGameMenu
{
    [SerializeField] private GameObject gameoverUI;
    [SerializeField] private float deathDelay = 3f;

    private void Awake()
    {
        if (gameoverUI == null)
            Debug.LogWarning($"Nessun menu di pausa associato su {gameObject.name}");

        if (gameoverUI != null)
            gameoverUI.SetActive(false);
    }

    public void StartDeathCoroutine()
    {
        StartCoroutine(DeathSequence());
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private IEnumerator DeathSequence()
    {
        yield return new WaitForSecondsRealtime(deathDelay);
        ShowGameoverUI();
    }

    private void ShowGameoverUI()
    {
        if (gameoverUI != null)
        {
            gameoverUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
