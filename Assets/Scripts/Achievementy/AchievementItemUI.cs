using UnityEngine;
using UnityEngine.UI;

public class AchievementItemUI : MonoBehaviour, IAchievementItemUI
{
    public Text titleText;
    public Text descriptionText;
    public Image iconImage;

    public void Setup(AchievementSO achievement)
    {
        titleText.text = achievement.title;
        descriptionText.text = achievement.description;
        iconImage.sprite = achievement.icon;
    }
}
