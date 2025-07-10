using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResetPrefs : MonoBehaviour
{
    public Button resetButton; // P�et�hni UI tla��tko sem v inspektoru

    void Start()
    {
        if (resetButton != null)
        {
            resetButton.onClick.AddListener(ResetPlayerPrefs);
            Debug.Log("?? Reset button p�ipojen.");
        }
        else
        {
            Debug.LogWarning("?? Reset button nen� p�ipojen v inspektoru!");
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
        Debug.Log("?? PlayerPrefs byly resetov�ny!");

        // Na�ten� aktu�ln� sc�ny znovu (aby se zm�ny projevily)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
