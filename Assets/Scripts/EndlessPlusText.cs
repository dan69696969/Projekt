using UnityEngine;
using UnityEngine.UI;

public class EndlessPlusText : MonoBehaviour
{
    [Header("Refs")]
    public Text thisText;                // přetáhni v prefabu
    public RectTransform targetArea;     // tady přetáhneš tlačítko

    [Header("Timing & Motion")]
    public float lifetime = 0.5f;
    public float speed = 50f;

    private float timer = 0f;
    private Color startColor;

    void Start()
    {
        // najdi Canvas a nastav jako rodiče
        GameObject canvas = GameObject.Find("Canvas1");
        if (canvas != null)
        {
            transform.SetParent(canvas.transform, false);
        }
        else
        {
            Debug.LogWarning("Canvas1 not found! Text won't be displayed.");
        }

        // pokud targetArea není nastavený, najdi tlačítko ručně
        if (targetArea == null)
        {
            GameObject button = GameObject.Find("ClickButton"); // <- název tvého tlačítka
            if (button != null)
            {
                targetArea = button.GetComponent<RectTransform>();
            }
        }

        // Výpočet náhodné pozice v rámci targetArea
        if (targetArea != null)
        {
            Vector2 size = targetArea.rect.size;
            Vector2 randomPos = new Vector2(
                Random.Range(-size.x / 2f, size.x / 2f),
                Random.Range(-size.y / 2f, size.y / 2f)
            );
            transform.localPosition = targetArea.localPosition + (Vector3)randomPos;
        }
        else
        {
            transform.localPosition = Vector3.zero; // fallback
        }

        // nastav text
        thisText.text = "+" + EndlessGame.hitPower;

        // fade barva
        startColor = thisText.color;
    }

    void Update()
    {
        timer += Time.deltaTime;

        // pohyb nahoru
        transform.localPosition += Vector3.up * speed * Time.deltaTime;

        // alpha fade
        float alpha = Mathf.Lerp(1f, 0f, timer / lifetime);
        thisText.color = new Color(startColor.r, startColor.g, startColor.b, alpha);

        if (timer >= lifetime)
        {
            Destroy(gameObject);
        }
    }
}
    