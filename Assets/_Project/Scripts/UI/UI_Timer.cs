using TMPro;
using UnityEngine;

public class UI_Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;
        UpdateTimer();
    }

    public void UpdateTimer()
    {
        int minutes = (int)(timer / 60f);
        int seconds = (int)(timer % 60f);
        timerText.SetText($"{minutes:00}:{seconds:00}");
    }
}
