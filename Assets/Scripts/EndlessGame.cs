using System;
using System.Collections;
using TMPro;
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
    private float baseHitPower; 
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

    public int shopAprice;
    public Text shopAtext;
    public int amountA;
    public float amountAProfit;
    public Text amountAText;

    public int shopBprice;
    public Text shopBtext;
    public int amountB;
    public float amountBProfit;
    public Text amountBText;

    public int shopCprice;
    public Text shopCtext;
    public int amountC;
    public float amountCProfit;
    public Text amountCText;

    public int shopDprice;
    public Text shopDtext;
    public int amountD;
    public float amountDProfit;
    public Text amountDText;

    private float scoreThreshold = 50;
    private int lastBackgroundIndex = 0;

    public int bestScore;
    public Text bestScoreText;

    public bool achievement1;
    public bool achievement2;
    public bool achievement3;
    public bool achievement4;

    public Image image1;
    public Image image2;
    public Image image3;
    public Image image4;

    public bool nowIsEvent;
    public GameObject goldButton;

    public AchievementSO achScore1;
    public AchievementSO achScore100;
    public AchievementSO achScore500;
    public AchievementSO achScore5000;
    public AchievementSO achScore50000;

    [Header("Boost Settings")]
    public Image boostBarImage;
    private float boostValue = 0f;
    private float maxBoostValue = 100f;
    private float boostDecayRate = 15f;
    private float boostIncreasePerClick = 4f;
    private bool boostActive = false;

    public TMP_Text hitPowerText;

  
    public int shopPower1Price;
    public TMP_Text shopPower1Text;
    public int power1Level;

    
    public int shopPower2Price;
    public TMP_Text shopPower2Text;
    public int power2Level;

    
    public int shopPower3Price;
    public TMP_Text shopPower3Text;
    public int power3Level;

  
    public int shopPower4Price;
    public TMP_Text shopPower4Text;
    public int power4Level;

    void Start()
    {
       
        shopPower1Price = PlayerPrefs.GetInt("shopPower1Price", 100);
        power1Level = PlayerPrefs.GetInt("power1Level", 0);

        shopPower2Price = PlayerPrefs.GetInt("shopPower2Price", 500);
        power2Level = PlayerPrefs.GetInt("power2Level", 0);

        shopPower3Price = PlayerPrefs.GetInt("shopPower3Price", 2000);
        power3Level = PlayerPrefs.GetInt("power3Level", 0);

        shopPower4Price = PlayerPrefs.GetInt("shopPower4Price", 10000);
        power4Level = PlayerPrefs.GetInt("power4Level", 0);

        currentScore = PlayerPrefs.GetFloat("currentScore", 0);
        bestScore = PlayerPrefs.GetInt("bestScore", 0);

        shop1price = PlayerPrefs.GetInt("shop1price", 50);
        shop2price = PlayerPrefs.GetInt("shop2price", 500);
        shop3price = PlayerPrefs.GetInt("shop3price", 2500);

        shopAprice = PlayerPrefs.GetInt("shop4price", 50);
        amountA = PlayerPrefs.GetInt("amount4", 0);
        amountAProfit = PlayerPrefs.GetFloat("amount4Profit", 0);

        shopBprice = PlayerPrefs.GetInt("shop5price", 500);
        amountB = PlayerPrefs.GetInt("amount5", 0);
        amountBProfit = PlayerPrefs.GetFloat("amount5Profit", 0);

        shopCprice = PlayerPrefs.GetInt("shop6price", 2500);
        amountC = PlayerPrefs.GetInt("amount6", 0);
        amountCProfit = PlayerPrefs.GetFloat("amount6Profit", 0);

        shopDprice = PlayerPrefs.GetInt("shop7price", 10000);
        amountD = PlayerPrefs.GetInt("amount7", 0);
        amountDProfit = PlayerPrefs.GetFloat("amount7Profit", 0);

        amount1 = PlayerPrefs.GetInt("amount1", 0);
        amount1Profit = PlayerPrefs.GetFloat("amount1Profit", 0);
        amount2 = PlayerPrefs.GetInt("amount2", 0);
        amount2Profit = PlayerPrefs.GetFloat("amount2Profit", 0);
        amount3 = PlayerPrefs.GetInt("amount3", 0);
        amount3Profit = PlayerPrefs.GetFloat("amount3Profit", 0);

        achievement1 = PlayerPrefs.GetInt("achievement1", 0) == 1;
        achievement2 = PlayerPrefs.GetInt("achievement2", 0) == 1;
        achievement3 = PlayerPrefs.GetInt("achievement3", 0) == 1;
        achievement4 = PlayerPrefs.GetInt("achievement4", 0) == 1;

        
        baseHitPower = 1f
            + power1Level * 0.1f
            + power2Level * 0.5f
            + power3Level * 1f
            + power4Level * 5f;

        hitPower = baseHitPower;

        scoreIncreasedPerSecond = 1;
        x = 0f;

        backgroundControl = FindObjectOfType<BackgroundControl_0>();

        DateTime currentDate = DateTime.Now;
        string dateKey = currentDate.ToString("MM-dd");

        switch (dateKey)
        {
            case "01-01": SceneManager.LoadScene("NewYearScene"); break;
            case "02-14": SceneManager.LoadScene("ValentineScene"); break;
            case "12-25": SceneManager.LoadScene("ChristmasScene"); break;
        }
    }

    void Update()
    {
        hitPowerText.text = "Power: " + baseHitPower.ToString("F1");

        EventSystem.current.SetSelectedGameObject(mainClickButton.gameObject);

        shopPower1Text.text = shopPower1Price.ToString();
        shopPower2Text.text = shopPower2Price.ToString();
        shopPower3Text.text = shopPower3Price.ToString();
        shopPower4Text.text = shopPower4Price.ToString();

        if (Input.GetKeyDown(KeyCode.W))
            currentScore += 1000000;

        // ---------------- BOOST ----------------
        boostValue -= boostDecayRate * Time.deltaTime;
        boostValue = Mathf.Clamp(boostValue, 0f, maxBoostValue);

        // procento nabití (0 až 1)
        float t = boostValue / maxBoostValue;

        // barva se interpoluje mezi šedou a bílou
        if (boostBarImage != null)
        {
            boostBarImage.color = Color.Lerp(new Color(0.5f, 0.5f, 0.5f, 1f), Color.white, t);
            boostBarImage.fillAmount = t;
        }

        // aktivní boost když skoro plnej
        if (boostValue >= maxBoostValue * 0.9f)
        {
            boostActive = true;
            hitPower = baseHitPower * 2f;
        }
        else
        {
            boostActive = false;
            hitPower = baseHitPower;
        }

        // ---------------- SCORE ----------------
        scoreIncreasedPerSecond = (amount1Profit + amount2Profit + amount3Profit + amountAProfit + amountBProfit + amountCProfit + amountDProfit) * Time.deltaTime;
        currentScore += scoreIncreasedPerSecond;

        scoreText.text = ((int)currentScore).ToString();

        shop1text.text = shop1price.ToString();
        shop2text.text = shop2price.ToString();
        shop3text.text = shop3price.ToString();
        shopAtext.text = shopAprice.ToString();
        shopBtext.text = shopBprice.ToString();
        shopCtext.text = shopCprice.ToString();
        shopDtext.text = shopDprice.ToString();

        amount1Text.text = $"Level 1: {amount1}x profit: {amount1Profit}/s";
        amount2Text.text = $"Level 2: {amount2}x profit: {amount2Profit}/s";
        amount3Text.text = $"Level 3: {amount3}x profit: {amount3Profit}/s";
        amountAText.text = $"Level 4: {amountA}x profit: {amountAProfit}/s";
        amountBText.text = $"Level 5: {amountB}x profit: {amountBProfit}/s";
        amountCText.text = $"Level 6: {amountC}x profit: {amountCProfit}/s";
        amountDText.text = $"Level 7: {amountD}x profit: {amountDProfit}/s";

        if (currentScore > bestScore)
        {
            bestScore = (int)currentScore;
            PlayerPrefs.SetInt("bestScore", bestScore);
        }

        bestScoreText.text = "Best Score " + bestScore;

        // ---------------- ACHIEVEMENTS ----------------
        if (!achievement1 && currentScore >= 1)
        {
            achievement1 = true;
            AchievementManager.Instance.UnlockAchievement(achScore1);
            PlayerPrefs.SetInt("achievement1", 1);
        }
        if (!achievement2 && currentScore >= 100)
        {
            achievement2 = true;
            AchievementManager.Instance.UnlockAchievement(achScore100);
            PlayerPrefs.SetInt("achievement2", 1);
        }
        if (!achievement3 && currentScore >= 500)
        {
            achievement3 = true;
            AchievementManager.Instance.UnlockAchievement(achScore500);
            PlayerPrefs.SetInt("achievement3", 1);
        }
        if (!achievement4 && currentScore >= 5000)
        {
            achievement4 = true;
            AchievementManager.Instance.UnlockAchievement(achScore5000);
            PlayerPrefs.SetInt("achievement4", 1);
        }

        image1.color = achievement1 ? Color.white : new Color(0.2f, 0.2f, 0.2f, 0.2f);
        image2.color = achievement2 ? Color.white : new Color(0.2f, 0.2f, 0.2f, 0.2f);
        image3.color = achievement3 ? Color.white : new Color(0.2f, 0.2f, 0.2f, 0.2f);
        image4.color = achievement4 ? Color.white : new Color(0.2f, 0.2f, 0.2f, 0.2f);

        // ---------------- GOLD EVENT ----------------
        if (!nowIsEvent && goldButton.activeSelf)
        {
            goldButton.SetActive(false);
            StartCoroutine(WaitForEvent());
        }
        if (nowIsEvent && !goldButton.activeSelf)
        {
            goldButton.SetActive(true);
            goldButton.transform.position = new Vector3(UnityEngine.Random.Range(0, 751), UnityEngine.Random.Range(0, 401), 0);
        }

        PlayerPrefs.SetFloat("currentScore", currentScore);
    }


    public void Hit()
    {
        currentScore += hitPower;
        Instantiate(plusObject, transform.position, transform.rotation);
        CheckBackgroundChange();

        boostValue += boostIncreasePerClick;
        if (boostValue > maxBoostValue)
            boostValue = maxBoostValue;
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
        PlayerPrefs.SetFloat("currentScore", currentScore);
    }

    // ------------------ SHOPY ------------------

    public void Shop1()
    {
        if (currentScore >= shop1price)
        {
            currentScore -= shop1price;
            amount1++;
            amount1Profit += 1;
            x += 1;
            shop1price += 25;

            PlayerPrefs.SetInt("amount1", amount1);
            PlayerPrefs.SetFloat("amount1Profit", amount1Profit);
            PlayerPrefs.SetInt("shop1price", shop1price);
        }
    }

    public void Shop2()
    {
        if (currentScore >= shop2price)
        {
            currentScore -= shop2price;
            amount2++;
            amount2Profit += 5;
            x += 5;
            shop2price += 500;

            PlayerPrefs.SetInt("amount2", amount2);
            PlayerPrefs.SetFloat("amount2Profit", amount2Profit);
            PlayerPrefs.SetInt("shop2price", shop2price);
        }
    }

    public void Shop3()
    {
        if (currentScore >= shop3price)
        {
            currentScore -= shop3price;
            amount3++;
            amount3Profit += 25;
            x += 25;
            shop3price += 2500;

            PlayerPrefs.SetInt("amount3", amount3);
            PlayerPrefs.SetFloat("amount3Profit", amount3Profit);
            PlayerPrefs.SetInt("shop3price", shop3price);
        }
    }

    public void ShopA()
    {
        if (currentScore >= shopAprice)
        {
            currentScore -= shopAprice;
            amountA++;
            amountAProfit += 1;
            x += 1;
            shopAprice += 25;

            PlayerPrefs.SetInt("amount4", amountA);
            PlayerPrefs.SetFloat("amount4Profit", amountAProfit);
            PlayerPrefs.SetInt("shop4price", shopAprice);
        }
    }

    public void ShopB()
    {
        if (currentScore >= shopBprice)
        {
            currentScore -= shopBprice;
            amountB++;
            amountBProfit += 5;
            x += 5;
            shopBprice += 500;

            PlayerPrefs.SetInt("amount5", amountB);
            PlayerPrefs.SetFloat("amount5Profit", amountBProfit);
            PlayerPrefs.SetInt("shop5price", shopBprice);
        }
    }

    public void ShopC()
    {
        if (currentScore >= shopCprice)
        {
            currentScore -= shopCprice;
            amountC++;
            amountCProfit += 25;
            x += 25;
            shopCprice += 1250;

            PlayerPrefs.SetInt("amount6", amountC);
            PlayerPrefs.SetFloat("amount6Profit", amountCProfit);
            PlayerPrefs.SetInt("shop6price", shopCprice);
        }
    }

    public void ShopD()
    {
        if (currentScore >= shopDprice)
        {
            currentScore -= shopDprice;
            amountD++;
            amountDProfit += 125;
            x += 125;
            shopDprice += 5000;

            PlayerPrefs.SetInt("amount7", amountD);
            PlayerPrefs.SetFloat("amount7Profit", amountDProfit);
            PlayerPrefs.SetInt("shop7price", shopDprice);
        }
    }

    // ------------------ POWER SHOPY ------------------

    public void ShopPower1()
    {
        if (currentScore >= shopPower1Price)
        {
            currentScore -= shopPower1Price;
            power1Level++;
            baseHitPower += 0.1f;
            shopPower1Price += 100;

            PlayerPrefs.SetInt("shopPower1Price", shopPower1Price);
            PlayerPrefs.SetInt("power1Level", power1Level);
        }
    }

    public void ShopPower2()
    {
        if (currentScore >= shopPower2Price)
        {
            currentScore -= shopPower2Price;
            power2Level++;
            baseHitPower += 0.5f;
            shopPower2Price += 250;

            PlayerPrefs.SetInt("shopPower2Price", shopPower2Price);
            PlayerPrefs.SetInt("power2Level", power2Level);
        }
    }

    public void ShopPower3()
    {
        if (currentScore >= shopPower3Price)
        {
            currentScore -= shopPower3Price;
            power3Level++;
            baseHitPower += 1f;
            shopPower3Price += 1000;

            PlayerPrefs.SetInt("shopPower3Price", shopPower3Price);
            PlayerPrefs.SetInt("power3Level", power3Level);
        }
    }

    public void ShopPower4()
    {
        if (currentScore >= shopPower4Price)
        {
            currentScore -= shopPower4Price;
            power4Level++;
            baseHitPower += 5f;
            shopPower4Price += 5000;

            PlayerPrefs.SetInt("shopPower4Price", shopPower4Price);
            PlayerPrefs.SetInt("power4Level", power4Level);
        }
    }

    // ------------------ cislicka----------------

    public void GetReward()
    {
        currentScore += UnityEngine.Random.Range(50, 150);
        nowIsEvent = false;
        StartCoroutine(WaitForEvent());
    }

    IEnumerator WaitForEvent()
    {
        yield return new WaitForSeconds(5f);

        if (UnityEngine.Random.Range(1, 3) == 2)
        {
            nowIsEvent = true;
        }
        else
        {
            goldButton.SetActive(true);
        }
    }
}
