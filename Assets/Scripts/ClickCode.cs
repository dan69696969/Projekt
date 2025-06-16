using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClickCode : MonoBehaviour
{
    private Button button;
    private int clicksRequired = 10;
    private int clicked;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        clicked++;

        if(clicked >= clicksRequired)
        {
            SceneManager.LoadScene(15);
        }
    }
}
