using UnityEngine;

[CreateAssetMenu(fileName = "NewAchievement", menuName = "ClickFever/Achievement")]
public class AchievementSO : ScriptableObject
{
    [Header("Meta")]
    public string id;              // Napø. "CLICK_MASTER"
    public string title;
    [TextArea] public string description;
    public Sprite icon;

    [Header("Podmínka")]
    public RequirementType type;   // Typ podmínky (enum níže)
    public int goalValue;          // Napø. 1000 klikù
}

public enum RequirementType
{
    TotalClicks,
    MoneyEarned,
    // Pøidáme další pozdìji
}
