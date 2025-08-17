using UnityEngine;
using System.Collections.Generic;

public class AchievementManager : MonoBehaviour
{
    public static AchievementManager Instance;

    public GameObject popupPrefab;

    [Header("Všechny achievementy")]
    public AchievementSO[] allAchievements; // Přetáhni sem všechny v inspektoru

    private List<AchievementSO> unlockedAchievements = new List<AchievementSO>();
    private const string PlayerPrefsKey = "UnlockedAchievements";

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadAchievements(); // načtení při startu
        }
        else
        {
            Destroy(gameObject);
        }
    }

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

    public void UnlockAchievement(AchievementSO ach)
    {
        if (!unlockedAchievements.Contains(ach))
        {
            unlockedAchievements.Add(ach);
            SaveAchievements();
            Debug.Log("Achievement odemknut: " + ach.name);
            ShowAchievementPopup(ach);
        }
    }

    public List<AchievementSO> GetUnlockedAchievements()
    {
        return unlockedAchievements;
    }

    private void SaveAchievements()
    {
        List<string> ids = new List<string>();
        foreach (var ach in unlockedAchievements)
        {
            ids.Add(ach.id);
        }

        string saveString = string.Join(",", ids);
        PlayerPrefs.SetString(PlayerPrefsKey, saveString);
        PlayerPrefs.Save();
    }

    private void LoadAchievements()
    {
        unlockedAchievements.Clear();

        if (PlayerPrefs.HasKey(PlayerPrefsKey))
        {
            string saveString = PlayerPrefs.GetString(PlayerPrefsKey);
            string[] ids = saveString.Split(',');

            foreach (var id in ids)
            {
                if (string.IsNullOrEmpty(id)) continue;

                AchievementSO ach = FindAchievementById(id);
                if (ach != null)
                {
                    unlockedAchievements.Add(ach);
                }
                else
                {
                    Debug.LogWarning("Achievement s ID " + id + " nebyl nalezen!");
                }
            }
        }
    }

    private AchievementSO FindAchievementById(string id)
    {
        foreach (var ach in allAchievements)
        {
            if (ach.id == id)
                return ach;
        }
        return null;
    }
}
