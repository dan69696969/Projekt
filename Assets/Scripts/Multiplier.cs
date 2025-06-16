using UnityEngine;
using UnityEngine.UI;

public class Multiplier : MonoBehaviour
{
    public Game game;  
    public Text upgradeText;

    public int upgradeCost = 50;

    void Start()
    {
        game = FindObjectOfType<Game>(); 
        UpdateButtonText();
    }

    public void Upgrade()
    {
        if (game.currentScore >= upgradeCost)
        {
            game.currentScore -= upgradeCost;
            Game.hitPower *= 2;
            upgradeCost *= 4;
            UpdateButtonText();
        }
        else
        {
            Debug.Log("Málo penìz!");
        }
    }

    private void UpdateButtonText()
    {
        if (upgradeText != null)
        {
            upgradeText.text =  upgradeCost + " $";
        }
    }
}