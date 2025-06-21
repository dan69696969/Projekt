using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Rainbow : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Image image;
    private bool isHovering = false;
    private float hue = 0f;

    void Start()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {
        if (isHovering && image != null)
        {
            hue += Time.deltaTime * 0.2f;
            if (hue > 1f) hue = 0f;
            image.color = Color.HSVToRGB(hue, 1f, 1f);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovering = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovering = false;
        image.color = Color.white;
    }
}