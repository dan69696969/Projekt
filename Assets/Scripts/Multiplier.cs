using UnityEngine;
using UnityEngine.UI;

public class Multiplier : MonoBehaviour
{
    public Game game;  // Spr�vn� odkaz na Game skript
    public Text upgradeText;

    public int upgradeCost = 50;

    void Start()
    {
        if (game == null)
            game = FindObjectOfType<Game>();

        UpdateButtonText();
    }

    public void Upgrade()
    {
        if (game == null)
        {
            game = FindObjectOfType<Game>();
            if (game == null)
            {
                Debug.LogWarning("Game skript nebyl nalezen � upgrade se neprovede.");
                return;
            }
        }

        if (game.currentScore >= upgradeCost)
        {
            game.currentScore -= upgradeCost;
            Game.hitPower *= 2;  // Zv��� s�lu kliknut�
            upgradeCost *= 4;    // Zv�t�� cenu upgradu
            UpdateButtonText();
        }
        else
        {
            Debug.Log("M� m�lo pen�z!");
        }
    }

    private void UpdateButtonText()
    {
        if (upgradeText != null)
        {
            upgradeText.text = upgradeCost + " $";
        }
        else
        {
            Debug.LogWarning("Text tla��tka nen� nastaven!");
        }
    }
}
