using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundControl_0 : MonoBehaviour
{
    [Header("BackgroundNum 0 -> 3")]
    public int backgroundNum = 0;
    public Sprite[] Layer_Sprites;
    private GameObject[] Layer_Object = new GameObject[5];
    private int max_backgroundNum = 3;

    [Header("Reference na skript s počtem kliknutí")]
    public ClickManager clickManager;

    [Header("Změna vzhledu tlačítka")]
    public Button clickButton;
    public Sprite[] buttonNormalSprites;
    public Sprite[] buttonPressedSprites;

    private int[] thresholds = { 10, 20, 30 };
    private int currentThresholdIndex = 0;

    void Awake()
    {
        backgroundNum = PlayerPrefs.GetInt("BackgroundNum", 0);
        currentThresholdIndex = backgroundNum;
    }

    void Start()
    {
        for (int i = 0; i < Layer_Object.Length; i++)
        {
            Layer_Object[i] = GameObject.Find("Layer_" + i);
            if (Layer_Object[i] == null)
                Debug.LogError("Layer_" + i + " nebyl nalezen!");
        }

        ChangeSprite();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow)) NextBG();
        if (Input.GetKeyDown(KeyCode.LeftArrow)) BackBG();

        if (backgroundNum >= max_backgroundNum)
            return;

        if (currentThresholdIndex < thresholds.Length &&
            clickManager != null &&
            clickManager.clickCount >= thresholds[currentThresholdIndex])
        {
            backgroundNum = currentThresholdIndex + 1;
            currentThresholdIndex++;
            PlayerPrefs.SetInt("BackgroundNum", backgroundNum);
            PlayerPrefs.Save();
            ChangeSprite();
        }
    }

    void ChangeSprite()
    {
        if (backgroundNum < 0 || backgroundNum > max_backgroundNum) return;

        Layer_Object[0].GetComponent<SpriteRenderer>().sprite = Layer_Sprites[backgroundNum * 5];
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

        // 🎯 Změna tlačítka (Normal & Pressed)
        if (clickButton != null &&
            buttonNormalSprites.Length > backgroundNum &&
            buttonPressedSprites.Length > backgroundNum)
        {
            SpriteState spriteState = new SpriteState();
            spriteState.pressedSprite = buttonPressedSprites[backgroundNum];

            clickButton.image.sprite = buttonNormalSprites[backgroundNum];
            clickButton.spriteState = spriteState;
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
