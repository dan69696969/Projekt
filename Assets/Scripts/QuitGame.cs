using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuitGame : MonoBehaviour
{
    public GameObject hiddenText; // pøipoj v inspectoru
    private int clickCount = 0;
    public float quitDelay = 2f; // zpoždìní v sekundách

    public void OnExitClick()
    {
        clickCount++;

        if (clickCount == 1)
        {
            Debug.Log("První kliknutí – hra se ukonèí za chvilku...");
            StartCoroutine(QuitAfterDelay());
        }
        else
        {
            Debug.Log("Více kliknutí – zobrazím skrytý text!");
            if (hiddenText != null)
                hiddenText.SetActive(true);
        }
    }

    private IEnumerator QuitAfterDelay()
    {
        yield return new WaitForSeconds(quitDelay);
        Application.Quit();

        // pro testování v Editoru
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
