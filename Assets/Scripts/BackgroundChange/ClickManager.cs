using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public int clickCount = 0;

    void Start()
    {
        // Na�ti po�et kliknut� z PlayerPrefs (pokud existuje)
        clickCount = PlayerPrefs.GetInt("ClickCount", 0);
    }

    public void Click()
    {
        clickCount++;
        PlayerPrefs.SetInt("ClickCount", clickCount); // Ulo� po�et kliknut�
        PlayerPrefs.Save(); // Voliteln� � okam�it� ulo�en�
    }
}
