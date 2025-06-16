using UnityEngine;

public class Stop : MonoBehaviour
{
    public float scrollSpeed = 20f;
    public float scrollDuration = 5f; // 💥 ZASTAVÍ SE po X sekundách (můžeš změnit!)

    private RectTransform rectTransform;
    private float elapsedTime = 0f;
    private bool scrolling = true;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (!scrolling)
            return;

        elapsedTime += Time.deltaTime;

        if (elapsedTime >= scrollDuration)
        {
            scrolling = false;
            return;
        }

        rectTransform.anchoredPosition += new Vector2(scrollSpeed * Time.deltaTime, 0);
    }
}
