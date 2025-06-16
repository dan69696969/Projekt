using UnityEngine;
using TMPro;

public class Pulse : MonoBehaviour
{
    public float pulseSpeed = 1f;   // Rychlost pulzov�n�
    public float minScale = 1f;     // Minim�ln� velikost
    public float maxScale = 1.5f;   // Maxim�ln� velikost

    private TMP_Text textComponent;
    private Vector3 originalScale;

    void Start()
    {
        textComponent = GetComponent<TMP_Text>();
        originalScale = transform.localScale;
    }

    void Update()
    {
        // Vypo��tej offset pomoc� sinusov� funkce (hladk� kol�s�n� mezi 0 a 1)
        float t = (Mathf.Sin(Time.time * pulseSpeed) + 1f) / 2f;

        // Interpolace mezi min a max scale
        float scale = Mathf.Lerp(minScale, maxScale, t);

        // Nastaven� v�sledn� �k�ly
        transform.localScale = originalScale * scale;
    }
}
