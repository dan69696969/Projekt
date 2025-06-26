using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    public static AchievementManager Instance;

    public GameObject popupPrefab;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Metoda pro zobrazení popupu
    public void ShowAchievementPopup(AchievementSO ach)
    {
        Canvas canvas = FindObjectOfType<Canvas>();
        if (canvas == null)
        {
            Debug.LogWarning("Canvas nebyl nalezen – popup se neukáže.");
            return;
        }

        GameObject go = Instantiate(popupPrefab, canvas.transform);
        go.GetComponent<AchievementPopupUI>().ShowPopup(ach);
    }

    // NOVÁ METODA – volaná při odemknutí achievementu
    public void UnlockAchievement(AchievementSO ach)
    {
        // Tady můžeš přidat další logiku třeba uložení achievementu do PlayerPrefs

        Debug.Log("Achievement odemknut: " + ach.name);

        ShowAchievementPopup(ach);
    }
}
