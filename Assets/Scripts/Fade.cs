using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Fade : MonoBehaviour
{
    public Image fadeScreen;   // Èerná obrazovka pro fade efekt
    public float fadeSpeed = 0.2f;   // Rychlost fade efektu (èím nižší, tím pomalejší)

    private void Awake()
    {
        // Nastavení obrazovky na èernou a plnì neprùhlednou pøi startu
        if (fadeScreen != null)
        {
            fadeScreen.color = new Color(0, 0, 0, 1f);  // Èerná barva, plnì neprùhledná
        }
    }

    private void Start()
    {
        // Po naètení scény spustíme fade-in efekt
        if (fadeScreen != null)
        {
            StartCoroutine(FadeIn());
        }
    }

    // Funkce pro pøepnutí na jinou scénu po fade-out efektu
    public void FadeAndLoadScene(string sceneName)
    {
        StartCoroutine(FadeOutAndLoadScene(sceneName));
    }

    // Fade-out + pøepnutí scény
    private IEnumerator FadeOutAndLoadScene(string sceneName)
    {
        // Spuštìní fade-out (obrazovka zèerná)
        yield return StartCoroutine(FadeOut());

        // Naètení nové scény
        SceneManager.LoadScene(sceneName);

        // Po naètení scény spustíme fade-in (obrazovka se rozsvítí)
        yield return StartCoroutine(FadeIn());
    }

    // Fade-out efekt: èerná obrazovka pomalu nabývá plné neprùhlednosti
    public IEnumerator FadeOut()
    {
        float alpha = 0f;
        while (alpha < 1f)
        {
            alpha += Time.deltaTime * fadeSpeed;  // Èím menší fadeSpeed, tím pomalejší fade
            fadeScreen.color = new Color(0, 0, 0, Mathf.Clamp01(alpha));  // Zvyšujeme neprùhlednost
            yield return null;
        }
    }

    // Fade-in efekt: èerná obrazovka pomalu mizí
    public IEnumerator FadeIn()
    {
        float alpha = 1f;
        while (alpha > 0f)
        {
            alpha -= Time.deltaTime * fadeSpeed;  // Èím menší fadeSpeed, tím pomalejší fade
            fadeScreen.color = new Color(0, 0, 0, Mathf.Clamp01(alpha));  // Snižujeme neprùhlednost
            yield return null;
        }
    }
}
