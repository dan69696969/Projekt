using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public int clickCount = 0;

    void Start()
    {
        // Naèti poèet kliknutí z PlayerPrefs (pokud existuje)
        clickCount = PlayerPrefs.GetInt("ClickCount", 0);
    }

    public void Click()
    {
        clickCount++;
        PlayerPrefs.SetInt("ClickCount", clickCount); // Ulož poèet kliknutí
        PlayerPrefs.Save(); // Volitelnì – okamžité uložení
    }
}
