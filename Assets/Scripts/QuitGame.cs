using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void OnExitClick()
    {
        Debug.Log("Kliknuto na tlaèítko pro ukonèení!");
        Application.Quit();
    }
}
