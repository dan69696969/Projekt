using UnityEngine;
using UnityEngine.UI;

public class AchievementDisplay : MonoBehaviour
{
    public Image icon;
    public Text titleText;
    public Text descriptionText;

    public void Setup(AchievementSO achievement, bool unlocked)
    {
        titleText.text = achievement.title;
        descriptionText.text = achievement.description;

        if (unlocked)
        {
            icon.sprite = achievement.icon;
            icon.color = Color.white;
        }
        else
        {
            icon.sprite = achievement.icon;
            icon.color = new Color(0.2f, 0.2f, 0.2f, 0.5f); // šedivá
        }
    }
}
