using UnityEngine;

public class AchievementListLoader : MonoBehaviour
{
    public AchievementSO[] allAchievements;        // Sem p�et�hni v�echny achievementy nebo pou�ij Resources.LoadAll
    public GameObject achievementItemPrefab;       // Prefab jedn� polo�ky (m� komponentu AchievementItemUI)
    public Transform contentParent;                 // Content z ScrollView (kam se budou instancovat polo�ky)

    void Start()
    {
        // Pokud chce� dynamiku, m��e� nahradit allAchievements t�mto:
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
                Debug.LogWarning("Prefab nem� komponentu implementuj�c� IAchievementItemUI!");
            }
        }
    }
}
