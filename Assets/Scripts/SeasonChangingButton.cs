using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SeasonChangingButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Image image;
    private bool isHovering = false;
    private float timer = 0f;
    private float switchInterval = 1.5f;
    private int currentIndex = 0;
    private int nextIndex = 1;
    private float transitionProgress = 0f;
    private float transitionSpeed = 1f; // rychlost pøechodu mezi barvami

    private Color[] seasonColors = new Color[]
    {
        new Color(0.2f, 0.8f, 0.2f), // Spring
        new Color(1f, 0.9f, 0.2f),   // Summer
        new Color(0.6f, 0.3f, 0.1f), // Autumn
        new Color(0.3f, 0.6f, 1f)    // Winter
    };

    void Start()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {
        if (isHovering && image != null)
        {
            timer += Time.deltaTime;
            transitionProgress += Time.deltaTime * transitionSpeed;

            // Smoothly interpolate between current and next color
            Color currentColor = Color.Lerp(seasonColors[currentIndex], seasonColors[nextIndex], transitionProgress);
            image.color = currentColor;

            // After time, move to next color
            if (timer >= switchInterval)
            {
                timer = 0f;
                transitionProgress = 0f;
                currentIndex = nextIndex;
                nextIndex = (nextIndex + 1) % seasonColors.Length;
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovering = true;
        timer = 0f;
        transitionProgress = 0f;
        currentIndex = 0;
        nextIndex = 1;
        image.color = seasonColors[0];
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovering = false;
        image.color = Color.white;
    }
}
