using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void OnExitClick()
    {
        Debug.Log("Kliknuto na tla��tko pro ukon�en�!");
        Application.Quit();
    }
}
