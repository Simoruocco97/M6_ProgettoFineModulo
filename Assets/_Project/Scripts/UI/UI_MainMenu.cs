using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_MainMenu : MonoBehaviour
{
    [SerializeField] private int MainLevelSceneInt = 1;

    public void OnStartButton()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(MainLevelSceneInt);
    }

    public void OnExitButton()
    {
        Application.Quit();
    }
}
