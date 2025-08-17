using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class OpenCloseAchievements : MonoBehaviour
{
    public GameObject achievementPanel;
    public void OpenPanel()
    {
        achievementPanel.SetActive(true);
    }
    public void ClosePanel()
    {
        achievementPanel.SetActive(false);
    }
}
