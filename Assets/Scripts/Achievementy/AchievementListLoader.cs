using UnityEngine;

public class AchievementListLoader : MonoBehaviour
{
    public AchievementSO[] allAchievements;        // Sem pøetáhni všechny achievementy nebo použij Resources.LoadAll
    public GameObject achievementItemPrefab;       // Prefab jedné položky (má komponentu AchievementItemUI)
    public Transform contentParent;                 // Content z ScrollView (kam se budou instancovat položky)

    void Start()
    {
        // Pokud chceš dynamiku, mùžeš nahradit allAchievements tímto:
        // allAchievements = Resources.LoadAll<AchievementSO>("Achievements");

        foreach (var achievement in allAchievements)
        {
            GameObject itemGO = Instantiate(achievementItemPrefab, contentParent);
            var itemUI = itemGO.GetComponent<IAchievementItemUI>();
            if (itemUI != null)
            {
                itemUI.Setup(achievement);
            }
            else
            {
                Debug.LogWarning("Prefab nemá komponentu implementující IAchievementItemUI!");
            }
        }
    }
}
