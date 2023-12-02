using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerScript : MonoBehaviour
{
    private float timer = 60f;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private GameManager gameManager;

    void Update()
    {
        // Update the timer
        if (timer > 0f)
        {
            timer -= Time.deltaTime;
            UpdateTimerDisplay();
        }
        else
        {
            // Timer has reached 0, call the function to stop game.
            timer = 0f;
            UpdateTimerDisplay();
        }

        if(timer <= 0f)
        {
            GameIsComplete();
        }
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void GameIsComplete()
    {
        gameManager.EndGame();
    }
}
