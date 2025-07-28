using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundControl_0 : MonoBehaviour
{
    [Header("BackgroundNum 0 -> 3")]
    public int backgroundNum = 0;
    public Sprite[] Layer_Sprites;
    private GameObject[] Layer_Object = new GameObject[5];
    private int max_backgroundNum = 3;

    [Header("Reference na skript s počtem kliknutí")]
    public ClickManager clickManager;

    private int[] thresholds = { 10, 20, 30 };
    private int currentThresholdIndex = 0;

    void Awake()
    {
        // Načti backgroundNum ze savů
        backgroundNum = PlayerPrefs.GetInt("BackgroundNum", 0);
        currentThresholdIndex = backgroundNum; // Aby nezačínalo od 0 znovu
    }

    void Start()
    {
        // Najdi vrstvy pozadí
        for (int i = 0; i < Layer_Object.Length; i++)
        {
            Layer_Object[i] = GameObject.Find("Layer_" + i);

            if (Layer_Object[i] == null)
            {
                Debug.LogError("Layer_" + i + " nebyl nalezen!");
            }
        }

        ChangeSprite(); // Načti počáteční pozadí
    }

    void Update()
    {
        // Ruční přepnutí pro prezentaci
        if (Input.GetKeyDown(KeyCode.RightArrow)) NextBG();
        if (Input.GetKeyDown(KeyCode.LeftArrow)) BackBG();

        // ❌ Pokud už je maximum dosaženo, nic víc se neděje
        if (backgroundNum >= max_backgroundNum)
            return;

        // Automatická změna podle kliků
        if (currentThresholdIndex < thresholds.Length &&
            clickManager != null &&
            clickManager.clickCount >= thresholds[currentThresholdIndex])
        {
            backgroundNum = currentThresholdIndex + 1;
            currentThresholdIndex++;
            PlayerPrefs.SetInt("BackgroundNum", backgroundNum); // 💾 uložíme stav
            PlayerPrefs.Save();
            ChangeSprite();
        }
    }

    void ChangeSprite()
    {
        if (backgroundNum < 0 || backgroundNum > max_backgroundNum) return;

        // Vrstva 0
        Layer_Object[0].GetComponent<SpriteRenderer>().sprite = Layer_Sprites[backgroundNum * 5];

        // Zbytek vrstev
        for (int i = 1; i < Layer_Object.Length; i++)
        {
            Sprite changeSprite = Layer_Sprites[backgroundNum * 5 + i];
            Layer_Object[i].GetComponent<SpriteRenderer>().sprite = changeSprite;

            if (Layer_Object[i].transform.childCount >= 2)
            {
                Layer_Object[i].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = changeSprite;
                Layer_Object[i].transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = changeSprite;
            }
        }
    }

    public void NextBG()
    {
        if (backgroundNum < max_backgroundNum)
        {
            backgroundNum++;
            currentThresholdIndex = backgroundNum;
            PlayerPrefs.SetInt("BackgroundNum", backgroundNum);
            PlayerPrefs.Save();
            ChangeSprite();
        }
    }

    public void BackBG()
    {
        if (backgroundNum > 0)
        {
            backgroundNum--;
            currentThresholdIndex = backgroundNum;
            PlayerPrefs.SetInt("BackgroundNum", backgroundNum);
            PlayerPrefs.Save();
            ChangeSprite();
        }
    }
}
