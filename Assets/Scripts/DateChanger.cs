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

        if (month >= 3 && month <= 5) // Jaro: b�ezen�kv�ten
        {
            sceneIndex = 14;
        }
        else if (month >= 6 && month <= 8) // L�to: �erven�srpen
        {
            sceneIndex = 3;
        }
        else if (month >= 9 && month <= 11) // Podzim: z���listopad
        {
            sceneIndex = 4;
        }
        else // Zima: prosinec��nor
        {
            sceneIndex = 5;
        }

        SceneManager.LoadScene(sceneIndex);
    }
}
