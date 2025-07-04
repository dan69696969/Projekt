using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundControl_0 : MonoBehaviour
{
    [Header("BackgroundNum 0 -> 3")]
    public int backgroundNum = 3; // Rovnou nastavit �tvrtou f�zi
    public Sprite[] Layer_Sprites;
    private GameObject[] Layer_Object = new GameObject[5];
    private int max_backgroundNum = 3;

    

    void Awake()
    {
        // Ujist�me se, �e backgroundNum je spr�vn� nastaven� p�ed jakoukoliv inicializac�
        backgroundNum = 3;
    } 

    void Start()
    {
        // Na�ten� vrstev pozad�
        for (int i = 0; i < Layer_Object.Length; i++)
        {
            Layer_Object[i] = GameObject.Find("Layer_" + i);

            // P�idat kontrolu, jestli objekt existuje
            if (Layer_Object[i] == null)
            {
                Debug.LogError("Layer_" + i + " nebyl nalezen!");
            }
        }

        ChangeSprite(); // Na�te rovnou 4. f�zi
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

        // Nastaven� hlavn� vrstvy
        Layer_Object[0].GetComponent<SpriteRenderer>().sprite = Layer_Sprites[backgroundNum * 5];

        // Nastaven� zbytku vrstev
        for (int i = 1; i < Layer_Object.Length; i++)
        {
            Sprite changeSprite = Layer_Sprites[backgroundNum * 5 + i];
            Layer_Object[i].GetComponent<SpriteRenderer>().sprite = changeSprite;

            // Zm�na sprite� i u d�t�
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
