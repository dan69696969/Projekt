using UnityEngine;

public class UIBackgroundScroll : MonoBehaviour
{
    public float scrollSpeed = 20f;
    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        rectTransform.anchoredPosition += new Vector2(scrollSpeed * Time.deltaTime, 0);
    }
}
