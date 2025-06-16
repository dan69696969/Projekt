using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class Kolotoc : MonoBehaviour, IPointerClickHandler
{
    public float bounceDuration = 0.3f;
    public float bounceScale = 1.3f;

    private Vector3 originalScale;
    private bool isBouncing = false;

    void Start()
    {
        originalScale = transform.localScale;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isBouncing)
            StartCoroutine(Bounce());
    }

    System.Collections.IEnumerator Bounce()
    {
        isBouncing = true;
        float timer = 0f;

        while (timer < bounceDuration / 2f)
        {
            float t = timer / (bounceDuration / 2f);
            transform.localScale = Vector3.Lerp(originalScale, originalScale * bounceScale, t);
            timer += Time.deltaTime;
            yield return null;
        }

        timer = 0f;
        while (timer < bounceDuration / 2f)
        {
            float t = timer / (bounceDuration / 2f);
            transform.localScale = Vector3.Lerp(originalScale * bounceScale, originalScale, t);
            timer += Time.deltaTime;
            yield return null;
        }

        transform.localScale = originalScale;
        isBouncing = false;
    }
}
