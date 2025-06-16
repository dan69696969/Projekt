using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountdownTimerSpring : MonoBehaviour
{
    public float timeRemaining = 30f;
    public TextMeshProUGUI timerText;
    private bool timerIsRunning = true;
    Game score;

    private void Start()
    {
        score = FindObjectOfType<Game>();
        if (score != null) Debug.Log("neni null");
        else Debug.Log("je null");
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                Debug.Log(score.currentScore);
                timeRemaining -= Time.deltaTime;
                UpdateTimerDisplay(timeRemaining);
            }
            else
            {
                // Konec èasovaèe
                timeRemaining = 0;
                timerIsRunning = false;
                UpdateTimerDisplay(timeRemaining);
                Debug.Log("Timer ended!");
                Debug.Log("Current Score: " + score.currentScore);


                if (score.currentScore < 10000)
                {
                    SceneManager.LoadScene(8);
                }
                else
                {
                    SceneManager.LoadScene(12);
                }
            }
        }
    }

    void UpdateTimerDisplay(float timeToDisplay)
    {
        timeToDisplay = Mathf.Max(timeToDisplay, 0);

        int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
