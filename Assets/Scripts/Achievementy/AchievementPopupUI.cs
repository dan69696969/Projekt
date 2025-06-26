using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AchievementPopupUI : MonoBehaviour
{
    public Text titleText;
    public Text descriptionText;
    public Image iconImage;
    public float showDuration = 3f;

    private Coroutine currentCoroutine;

    public void ShowPopup(AchievementSO achievement)
    {
        titleText.text = achievement.title;
        descriptionText.text = achievement.description;
        iconImage.sprite = achievement.icon;

        gameObject.SetActive(true);

        if (currentCoroutine != null)
            StopCoroutine(currentCoroutine);

        currentCoroutine = StartCoroutine(HideAfterDelay());
    }

    private IEnumerator HideAfterDelay()
    {
        yield return new WaitForSeconds(showDuration);
        gameObject.SetActive(false);
    }
}