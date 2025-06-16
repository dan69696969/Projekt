using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CodeScript : MonoBehaviour
{
    public InputField codeInput;
    public Button confirmButton;
    public string correctCode = "RIZZ"; 
    public string sceneToLoad = "TvojeScena";

    private Text placeholderText;

    private void Start()
    {
        confirmButton.onClick.AddListener(CheckCode);

       
        placeholderText = codeInput.placeholder as Text;
    }

    private void CheckCode()
    {
        if (codeInput.text.ToLower().Trim() == correctCode.ToLower())
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            if (placeholderText != null)
            {
                placeholderText.text = "Incorrect code!";
            }

            codeInput.text = "";
            codeInput.ActivateInputField(); 
        }
    }
}
