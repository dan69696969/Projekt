using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AchievementPopupUI : MonoBehaviour
{
    public Text titleText;
    public Text descriptionText;
    public Image iconImage;
    public float showDuration = 3f;
    public float fadeDuration = 0.5f;

    private Coroutine currentCoroutine;
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
            canvasGroup = gameObject.AddComponent<CanvasGroup>();

        canvasGroup.alpha = 0;
        gameObject.SetActive(false);
    }

    public void ShowPopup(AchievementSO achievement)
    {
        titleText.text = achievement.title;
        descriptionText.text = achievement.description;
        iconImage.sprite = achievement.icon;

        gameObject.SetActive(true);

        if (currentCoroutine != null)
            StopCoroutine(currentCoroutine);

        currentCoroutine = StartCoroutine(ShowAndHideRoutine());
    }

    private IEnumerator ShowAndHideRoutine()
    {
        yield return StartCoroutine(FadeIn());
        yield return new WaitForSeconds(showDuration);
        yield return StartCoroutine(FadeOut());

        gameObject.SetActive(false);
    }

    private IEnumerator FadeIn()
    {
        float time = 0f;
        while (time < fadeDuration)
        {
            canvasGroup.alpha = Mathf.Lerp(0, 1, time / fadeDuration);
            time += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = 1;
    }

    private IEnumerator FadeOut()
    {
        float time = 0f;
        while (time < fadeDuration)
        {
            canvasGroup.alpha = Mathf.Lerp(1, 0, time / fadeDuration);
            time += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = 0;
    }
}
