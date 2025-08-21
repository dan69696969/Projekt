using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuitGame : MonoBehaviour
{
    public GameObject hiddenText; // p�ipoj v inspectoru
    private int clickCount = 0;
    public float quitDelay = 2f; // zpo�d�n� v sekund�ch

    public void OnExitClick()
    {
        clickCount++;

        if (clickCount == 1)
        {
            Debug.Log("Prvn� kliknut� � hra se ukon�� za chvilku...");
            StartCoroutine(QuitAfterDelay());
        }
        else
        {
            Debug.Log("V�ce kliknut� � zobraz�m skryt� text!");
            if (hiddenText != null)
                hiddenText.SetActive(true);
        }
    }

    private IEnumerator QuitAfterDelay()
    {
        yield return new WaitForSeconds(quitDelay);
        Application.Quit();

        // pro testov�n� v Editoru
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
