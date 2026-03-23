using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_InGameMenu : MonoBehaviour
{
    [SerializeField] private int mainMenuInt = 0;
    public void ReturnToMain()
    {
        //save
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenuInt);
    }
}
