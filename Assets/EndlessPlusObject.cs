using UnityEngine;
using UnityEngine.UI;

public class EndlessPlusObject : MonoBehaviour
{
    [Header("Timing & Motion")]
    public float lifetime = 0.5f; // Doba života v sekundách
    public float speed = 50f;     // Rychlost pohybu nahoru v px/s

    private float timer = 0f;
    private Color startColor;
    private Text thisText;


    void Start()
    {
        
        // Najdeme Text komponentu na tomto objektu
        thisText = GetComponent<Text>();
        if (thisText == null)
        {
            Debug.LogError("Chybí komponenta Text na EndlessPlusObject!");
            return;
        }

        // Najdeme hlavní canvas (Canvas1)
        GameObject canvas = GameObject.Find("Canvas1");
        if (canvas != null)
            transform.SetParent(canvas.transform, false);
        else
            Debug.LogWarning("Nenalezen objekt 'Canvas1'!");

        // Náhodná pozice (lokálnì)
        transform.localPosition = new Vector3(
            Random.Range(-200, 200),
            Random.Range(-300, 100),
            0f);

        // Nastavení textu podle hitPower
        thisText.text = "+" + EndlessGame.hitPower;

        // Uložíme barvu kvùli fade-out efektu
        startColor = thisText.color;
    }

    void Update()
    {
        timer += Time.deltaTime;

        // Pohyb nahoru
        transform.localPosition += Vector3.up * speed * Time.deltaTime;

        // Fade efekt
        float alpha = Mathf.Lerp(1f, 0f, timer / lifetime);
        thisText.color = new Color(startColor.r, startColor.g, startColor.b, alpha);

        // Znièení po uplynutí života
        if (timer >= lifetime)
            Destroy(gameObject);
    }
}
