using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class Dragging : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Tooltip("Když necháš prázdné, vezme nejbližší parent Canvas.")]
    public Canvas canvas;

    private RectTransform rectTransform;
    private RectTransform parentRect;
    private Vector2 pointerOffset;
    private Vector2 startAnchoredPos;

    private bool isDragging;   // flag jestli táhnu
    private Button button;     // odkaz na button (pokud je připojený)
    private Image image;       // odkaz na image, abychom zachovali barvu
    private Color originalColor;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        if (canvas == null) canvas = GetComponentInParent<Canvas>();
        parentRect = rectTransform.parent as RectTransform;

        button = GetComponent<Button>();
        image = GetComponent<Image>();
        if (image != null)
            originalColor = image.color;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        startAnchoredPos = rectTransform.anchoredPosition;
        isDragging = false;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (parentRect == null) return;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            parentRect, eventData.position, eventData.pressEventCamera, out var localPoint))
        {
            pointerOffset = localPoint - rectTransform.anchoredPosition;
            isDragging = true;

            // Zablokujeme kliknutí
            if (button != null)
                button.interactable = false;

            // Zachováme barvu / neprůhlednost
            if (image != null)
                image.color = originalColor;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (parentRect == null) return;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            parentRect, eventData.position, eventData.pressEventCamera, out var localPoint))
        {
            rectTransform.anchoredPosition = localPoint - pointerOffset;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Po skončení dragu povolíme klikání
        if (button != null)
            button.interactable = true;

        // Nepotřebujeme měnit barvu, ale můžeme ji resetovat pro jistotu
        if (image != null)
            image.color = originalColor;
    }
}
