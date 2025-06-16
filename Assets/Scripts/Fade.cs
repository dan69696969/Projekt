using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Fade : MonoBehaviour
{
    public Image fadeScreen;   // �ern� obrazovka pro fade efekt
    public float fadeSpeed = 0.2f;   // Rychlost fade efektu (��m ni���, t�m pomalej��)

    private void Awake()
    {
        // Nastaven� obrazovky na �ernou a pln� nepr�hlednou p�i startu
        if (fadeScreen != null)
        {
            fadeScreen.color = new Color(0, 0, 0, 1f);  // �ern� barva, pln� nepr�hledn�
        }
    }

    private void Start()
    {
        // Po na�ten� sc�ny spust�me fade-in efekt
        if (fadeScreen != null)
        {
            StartCoroutine(FadeIn());
        }
    }

    // Funkce pro p�epnut� na jinou sc�nu po fade-out efektu
    public void FadeAndLoadScene(string sceneName)
    {
        StartCoroutine(FadeOutAndLoadScene(sceneName));
    }

    // Fade-out + p�epnut� sc�ny
    private IEnumerator FadeOutAndLoadScene(string sceneName)
    {
        // Spu�t�n� fade-out (obrazovka z�ern�)
        yield return StartCoroutine(FadeOut());

        // Na�ten� nov� sc�ny
        SceneManager.LoadScene(sceneName);

        // Po na�ten� sc�ny spust�me fade-in (obrazovka se rozsv�t�)
        yield return StartCoroutine(FadeIn());
    }

    // Fade-out efekt: �ern� obrazovka pomalu nab�v� pln� nepr�hlednosti
    public IEnumerator FadeOut()
    {
        float alpha = 0f;
        while (alpha < 1f)
        {
            alpha += Time.deltaTime * fadeSpeed;  // ��m men�� fadeSpeed, t�m pomalej�� fade
            fadeScreen.color = new Color(0, 0, 0, Mathf.Clamp01(alpha));  // Zvy�ujeme nepr�hlednost
            yield return null;
        }
    }

    // Fade-in efekt: �ern� obrazovka pomalu miz�
    public IEnumerator FadeIn()
    {
        float alpha = 1f;
        while (alpha > 0f)
        {
            alpha -= Time.deltaTime * fadeSpeed;  // ��m men�� fadeSpeed, t�m pomalej�� fade
            fadeScreen.color = new Color(0, 0, 0, Mathf.Clamp01(alpha));  // Sni�ujeme nepr�hlednost
            yield return null;
        }
    }
}
