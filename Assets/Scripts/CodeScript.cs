using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class CodeScript : MonoBehaviour
{
    public InputField codeInput;
    public Button confirmButton;

    // 🔐 Libovolné kódy a jejich scény
    private Dictionary<string, string> codeToScene = new Dictionary<string, string>()
    {
        { "RIZZ", "WINWINWIN" },
        { "cats", "CatScene" },
        { "noob", "NoobScene" },
        { "COW", "MiracleCowScene" },
        { "PUU", "PUU" }
    };

    private Text placeholderText;

    private void Start()
    {
        confirmButton.onClick.AddListener(CheckCode);
        codeInput.onEndEdit.AddListener(OnInputEndEdit); // Pro ENTER
        placeholderText = codeInput.placeholder as Text;
    }

    private void OnInputEndEdit(string input)
    {
        // Pokud ENTER nebo NUMPAD ENTER
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            CheckCode();
        }
    }

    private void CheckCode()
    {
        string enteredCode = codeInput.text.Trim();

        foreach (var pair in codeToScene)
        {
            // Ignoruje velká/malá písmena
            if (string.Equals(enteredCode, pair.Key, System.StringComparison.OrdinalIgnoreCase))
            {
                SceneManager.LoadScene(pair.Value);
                return;
            }
        }

        // Špatný kód
        if (placeholderText != null)
            placeholderText.text = "Incorrect code!";

        codeInput.text = "";
        codeInput.ActivateInputField();
    }
}
