using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SummerBackground : MonoBehaviour
{
    [Header("BackgroundNum 0 -> 3")]
    public int backgroundNum = 3; 
    public Sprite[] Layer_Sprites;
    private GameObject[] Layer_Object = new GameObject[5];
    private int max_backgroundNum = 3;

    void Awake()
    {
        
        backgroundNum = 3;
    }

    void Start()
    {
      
        for (int i = 0; i < Layer_Object.Length; i++)
        {
            Layer_Object[i] = GameObject.Find("Layer_" + i);

          
            if (Layer_Object[i] == null)
            {
                Debug.LogError("Layer_" + i + " nebyl nalezen!");
            }
        }

        ChangeSprite(); 
    }

    void Update()
    {
        // Pro prezentaci bez UI
        if (Input.GetKeyDown(KeyCode.RightArrow)) NextBG();
        if (Input.GetKeyDown(KeyCode.LeftArrow)) BackBG();
    }

    void ChangeSprite()
    {
        if (backgroundNum < 0 || backgroundNum > max_backgroundNum) return;

        // Nastavení hlavní vrstvy
        Layer_Object[0].GetComponent<SpriteRenderer>().sprite = Layer_Sprites[backgroundNum * 5];

        // Nastavení zbytku vrstev
        for (int i = 1; i < Layer_Object.Length; i++)
        {
            Sprite changeSprite = Layer_Sprites[backgroundNum * 5 + i];
            Layer_Object[i].GetComponent<SpriteRenderer>().sprite = changeSprite;

            // Zmìna spriteù i u dìtí
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
            ChangeSprite();
        }
    }

    public void BackBG()
    {
        if (backgroundNum > 0)
        {
            backgroundNum--;
            ChangeSprite();
        }
    }
}
