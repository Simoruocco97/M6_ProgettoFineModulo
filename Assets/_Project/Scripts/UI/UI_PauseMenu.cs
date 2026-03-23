using UnityEngine;

public class UI_PauseMenu : UI_InGameMenu
{
    [SerializeField] private GameObject UI_Pause;
    private bool pauseOpen = false;

    private void Awake()
    {
        if (UI_Pause == null)
            Debug.LogWarning($"Nessun menu di pausa associato su {gameObject.name}");

        if (UI_Pause != null)
            UI_Pause.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (UI_Pause == null)
                return;

            pauseOpen = !pauseOpen;
            UI_Pause.SetActive(pauseOpen);
            Time.timeScale = pauseOpen ? 0f : 1f;
        }
    }
    public void Resume()
    {
        if (UI_Pause == null)
            return;

        pauseOpen = false;
        UI_Pause.SetActive(false);
        Time.timeScale = 1f;
    }
}