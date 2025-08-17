using UnityEngine;

public class UnlockedAchievementListLoader : MonoBehaviour
{
    public GameObject achievementItemPrefab;
    public Transform contentParent;

    public void ShowUnlocked()
    {
        // smaž starý položky
        foreach (Transform child in contentParent)
        {
            Destroy(child.gameObject);
        }

        var unlocked = AchievementManager.Instance.GetUnlockedAchievements();
        foreach (var achievement in unlocked)
        {
            GameObject itemGO = Instantiate(achievementItemPrefab, contentParent);
            var itemUI = itemGO.GetComponent<IAchievementItemUI>();
            if (itemUI != null)
            {
                itemUI.Setup(achievement);
            }
        }
    }
}
