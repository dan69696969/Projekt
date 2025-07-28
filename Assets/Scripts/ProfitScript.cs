using UnityEngine;
using UnityEngine.UI;

public class ProfitScript : MonoBehaviour
{
    public EndlessGame endlessGameScript;
    public Text profitText;

    void Update()
    {
        float totalProfit = endlessGameScript.amount1Profit +
                            endlessGameScript.amount2Profit +
                            endlessGameScript.amount3Profit +
                            endlessGameScript.amountAProfit +
                            endlessGameScript.amountBProfit +
                            endlessGameScript.amountCProfit +
                            endlessGameScript.amountDProfit;

        profitText.text = "Money/s: " + ((int)totalProfit).ToString();
    }
}