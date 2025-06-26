using UnityEngine;

[CreateAssetMenu(fileName = "NewAchievement", menuName = "ClickFever/Achievement")]
public class AchievementSO : ScriptableObject
{
    [Header("Meta")]
    public string id;              // Nap�. "CLICK_MASTER"
    public string title;
    [TextArea] public string description;
    public Sprite icon;

    [Header("Podm�nka")]
    public RequirementType type;   // Typ podm�nky (enum n�e)
    public int goalValue;          // Nap�. 1000 klik�
}

public enum RequirementType
{
    TotalClicks,
    MoneyEarned,
    // P�id�me dal�� pozd�ji
}
