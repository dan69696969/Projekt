using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndlessGame : MonoBehaviour
{
    public Button mainClickButton;

    public Text scoreText;
    public float currentScore;
    public static float hitPower;
    public float scoreIncreasedPerSecond;
    public float x;

    public GameObject plusObject;
    public BackgroundControl_0 backgroundControl;



    public int shop1price;
    public Text shop1text;

    public int shop2price;
    public Text shop2text;

    public int shop3price;
    public Text shop3text;

    public Text amount1Text;
    public int amount1;
    public float amount1Profit;

    public Text amount2Text;
    public int amount2;
    public float amount2Profit;

    public Text amount3Text;
    public int amount3;
    public float amount3Profit;

    private float scoreThreshold = 50;
    private int lastBackgroundIndex = 0;



    public int bestScore;
    public Text bestScoreText;



    public bool achievement1;
    public bool achievement2;
    public bool achievement3;

    public Image image1;
    public Image image2;
    public Image image3;

    public bool nowIsEvent;
    public GameObject goldButton;

    public AchievementSO achScore1;
    public AchievementSO achScore100;
    public AchievementSO achScore500;

    void Start()
    {
        DateTime currentDate = DateTime.Now;

        // Pøevod mìsíce a dne na string (napøíklad ð"01-27" pro 27. ledna)
        string dateKey = currentDate.ToString("MM-dd");
        Debug.Log(currentDate);

        switch (dateKey)
        {
            case "01-01": // Nový rok
                SceneManager.LoadScene("NewYearScene");
                break;
            case "02-14": // Valentýn
                SceneManager.LoadScene("ValentineScene");
                break;
            case "12-25": // Vánoce
                SceneManager.LoadScene("ChristmasScene");
                break;

        }
        backgroundControl = FindObjectOfType<BackgroundControl_0>();
        currentScore = 0;
        hitPower = 1;
        scoreIncreasedPerSecond = 1;
        x = 0f;

        bestScore = PlayerPrefs.GetInt("bestScore", 0);


        shop1price = 50;
        shop2price = 500;
        shop3price = 2500;
    }



    void Update()
    {

        if (EventSystem.current.currentSelectedGameObject != mainClickButton.gameObject)
        {
            EventSystem.current.SetSelectedGameObject(mainClickButton.gameObject);
        }
        {
            scoreIncreasedPerSecond = (amount1Profit + amount2Profit + amount3Profit) * Time.deltaTime;
            currentScore += scoreIncreasedPerSecond;

            scoreText.text = (int)currentScore + " ";

            shop1text.text = " " + shop1price + " ";
            shop2text.text = " " + shop2price + " ";
            shop3text.text = " " + shop3price + " ";

            amount1Text.text = "Level 1: " + amount1 + "x profit: " + amount1Profit + "/s";
            amount2Text.text = "Level 2: " + amount2 + "x profit: " + amount2Profit + "/s";
            amount3Text.text = "Level 3: " + amount3 + "x profit: " + amount3Profit + "/s";
        }

        PlayerPrefs.SetInt("bestScore", bestScore);


        if (!achievement1 && currentScore >= 1)
        {
            achievement1 = true;
            AchievementManager.Instance.UnlockAchievement(achScore1);
        }

        if (!achievement2 && currentScore >= 100)
        {
            achievement2 = true;
            AchievementManager.Instance.UnlockAchievement(achScore100);
        }

        if (!achievement3 && currentScore >= 500)
        {
            achievement3 = true;
            AchievementManager.Instance.UnlockAchievement(achScore500);
        }


        if (!achievement1 && currentScore >= 50) achievement1 = true;
        if (!achievement2 && currentScore >= 500) achievement2 = true;
        if (!achievement3 && currentScore >= 5000) achievement3 = true;

        image1.color = achievement1 ? new Color(1f, 1f, 1f, 1f) : new Color(0.2f, 0.2f, 0.2f, 0.2f);
        image2.color = achievement2 ? new Color(1f, 1f, 1f, 1f) : new Color(0.2f, 0.2f, 0.2f, 0.2f);
        image3.color = achievement3 ? new Color(1f, 1f, 1f, 1f) : new Color(0.2f, 0.2f, 0.2f, 0.2f);

        if (currentScore > bestScore) bestScore = (int)currentScore;

        bestScoreText.text = "Best Score " + bestScore;




        if (nowIsEvent == false && goldButton.active == true)
        {
            goldButton.SetActive(false);
            StartCoroutine(WaitForEvent());
        }

        if (nowIsEvent == true && goldButton.active == false)
        {
            goldButton.SetActive(true);
            goldButton.transform.position = new Vector3(UnityEngine.Random.Range(0, 751), UnityEngine.Random.Range(0, 401), 0);
        }

    }



    public void Hit()
    {
        Debug.Log("Hit");
        currentScore += hitPower;
        Instantiate(plusObject, transform.position, transform.rotation);
        CheckBackgroundChange();
    }




    IEnumerator Fly()
    {
        for (int i = 0; i < 19; i++)
        {
            yield return new WaitForSeconds(0.01f);
            plusObject.transform.position = new Vector3(plusObject.transform.position.x, plusObject.transform.position.y + 2, 0);
        }
        plusObject.SetActive(false);
    }




    private void CheckBackgroundChange()
    {
        if (currentScore >= scoreThreshold)
        {
            scoreThreshold *= 4;
            backgroundControl.NextBG();
        }
    }

    public void RestartGame()
    {
        currentScore = 0;
    }




    public void Shop1()
    {
        if (currentScore >= shop1price)
        {
            currentScore -= shop1price;
            amount1 += 1;
            amount1Profit += 1;
            x += 1;
            shop1price += 25;
        }
        else
        {
            Debug.Log("Málo penìz!");
        }
    }




    public void Shop2()
    {
        if (currentScore >= shop2price)
        {
            currentScore -= shop2price;
            amount2 += 1;
            amount2Profit += 5;
            x += 5;
            shop2price += 500;
        }
        else
        {
            Debug.Log("Málo penìz!");
        }
    }




    public void Shop3()
    {
        if (currentScore >= shop3price)
        {
            currentScore -= shop3price;
            amount3 += 1;
            amount3Profit += 25;
            x += 25;
            shop3price += 2500;
        }
        else
        {
            Debug.Log("Málo penìz!");
        }
    }




    public void GetReward()
    {
        currentScore = currentScore + UnityEngine.Random.Range(50, 150);
        nowIsEvent = false;
        StartCoroutine(WaitForEvent());
    }




    IEnumerator WaitForEvent()
    {
        yield return new WaitForSeconds(5f);

        int x = 0;
        x = UnityEngine.Random.Range(1, 3);

        if (x == 2)
        {
            nowIsEvent = true;
        }
        else
        {
            goldButton.SetActive(true);
        }
    }





}