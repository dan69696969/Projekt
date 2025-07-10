using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResetPrefs : MonoBehaviour
{
    public Button resetButton; // Pøetáhni UI tlaèítko sem v inspektoru

    void Start()
    {
        if (resetButton != null)
        {
            resetButton.onClick.AddListener(ResetPlayerPrefs);
            Debug.Log("?? Reset button pøipojen.");
        }
        else
        {
            Debug.LogWarning("?? Reset button není pøipojen v inspektoru!");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("?? Stisknuto R pro reset.");
            ResetPlayerPrefs();
        }
    }

    public void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Debug.Log("?? PlayerPrefs byly resetovány!");

        // Naètení aktuální scény znovu (aby se zmìny projevily)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
