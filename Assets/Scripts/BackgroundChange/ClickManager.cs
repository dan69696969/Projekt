using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public int clickCount = 0;

    void Start()
    {
        clickCount = PlayerPrefs.GetInt("ClickCount", 0);
    }

    public void Click()
    {
        clickCount++;
        PlayerPrefs.SetInt("ClickCount", clickCount);
        PlayerPrefs.Save();
        Debug.Log("ClickCount: " + clickCount);
    }
}
