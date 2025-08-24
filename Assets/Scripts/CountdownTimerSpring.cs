using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountdownTimerSpring : MonoBehaviour
{
    [Header("Timer Settings")]
    public float timeRemaining = 3f;
    public TextMeshProUGUI timerText;

    private bool timerIsRunning = true;
    private Game score;

    private void Start()
    {
        score = FindObjectOfType<Game>();
        UpdateTimerDisplay(timeRemaining);
        Debug.Log("✅ Timer start: " + timeRemaining + "s");
    }

    private void Update()
    {
        if (!timerIsRunning) return;

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerDisplay(timeRemaining);
            Debug.Log("⏳ Time left: " + timeRemaining);

            if (score.currentScore >= 70)
            {
                Debug.Log("➡ Loading Scene 13");
                SceneManager.LoadScene(12);
            }
        }
        else
        {
            // jen jednou
            timerIsRunning = false;
            timeRemaining = 0;
            UpdateTimerDisplay(timeRemaining);

            Debug.Log("⏹ Timer ended! Final Score: " + score.currentScore);

            if (score.currentScore < 70)
            {
                Debug.Log("➡ Loading Scene 9");
                SceneManager.LoadScene(8);
            }
            else
            {
                Debug.Log("➡ Loading Scene 13");
                SceneManager.LoadScene(12);
            }
        }
    }

    private void UpdateTimerDisplay(float timeToDisplay)
    {
        timeToDisplay = Mathf.Max(timeToDisplay, 0);

        int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);

        if (timerText != null)
            timerText.text = $"{minutes:00}:{seconds:00}";
    }
}
