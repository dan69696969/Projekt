using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DateChanger : MonoBehaviour
{
    public void ChangeSceneBasedOnDate()
    {
        DateTime now = DateTime.Now;
        int month = now.Month;

        int sceneIndex = 0;

        if (month >= 3 && month <= 5) // Jaro: bøezen–kvìten
        {
            sceneIndex = 14;
        }
        else if (month >= 6 && month <= 8) // Léto: èerven–srpen
        {
            sceneIndex = 3;
        }
        else if (month >= 9 && month <= 11) // Podzim: záøí–listopad
        {
            sceneIndex = 4;
        }
        else // Zima: prosinec–únor
        {
            sceneIndex = 5;
        }

        SceneManager.LoadScene(sceneIndex);
    }
}
