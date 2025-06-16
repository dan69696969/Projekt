using UnityEngine;
using TMPro;

public class Pulse : MonoBehaviour
{
    public float pulseSpeed = 1f;   // Rychlost pulzování
    public float minScale = 1f;     // Minimální velikost
    public float maxScale = 1.5f;   // Maximální velikost

    private TMP_Text textComponent;
    private Vector3 originalScale;

    void Start()
    {
        textComponent = GetComponent<TMP_Text>();
        originalScale = transform.localScale;
    }

    void Update()
    {
        // Vypoèítej offset pomocí sinusové funkce (hladké kolísání mezi 0 a 1)
        float t = (Mathf.Sin(Time.time * pulseSpeed) + 1f) / 2f;

        // Interpolace mezi min a max scale
        float scale = Mathf.Lerp(minScale, maxScale, t);

        // Nastavení výsledné škály
        transform.localScale = originalScale * scale;
    }
}
