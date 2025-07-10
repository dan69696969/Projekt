using UnityEngine;
using UnityEngine.UI;

public class PlusObject : MonoBehaviour
{
    [Header("Refs")]
    public Text thisText;                // přetáhni v prefabu

    [Header("Timing & Motion")]
    public float lifetime = 0.5f;        // jak dlouho žije
    public float speed = 50f;         // px/s nahoru

    private float timer = 0f;
    private Color startColor;

    void Start()
    {
        // Canvas & pozice
        GameObject canvas = GameObject.Find("Canvas1");
        transform.SetParent(canvas.transform, false);

        // náhodný offset
        transform.localPosition = new Vector3(
            Random.Range(-200, 200),
            Random.Range(-300, 100),
            0f);

        // nastav text podle aktuálního hitPower
        thisText.text = "+" + Game.hitPower;

        // uložíme startovní barvu (kvůli alpha lerpu)
        startColor = thisText.color;
    }

    void Update()
    {
        timer += Time.deltaTime;

        // pohyb nahoru
        transform.localPosition += Vector3.up * speed * Time.deltaTime;

        // ✨ FADE: lineárně snižujeme alpha
        float alpha = Mathf.Lerp(1f, 0f, timer / lifetime);
        thisText.color = new Color(startColor.r, startColor.g, startColor.b, alpha);

        // konec života
        if (timer >= lifetime)
            Destroy(gameObject);
    }
}
