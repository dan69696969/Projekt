using UnityEngine;
using UnityEngine.SceneManagement; 
using System; 

public class SceneChangerByDate : MonoBehaviour
{
    void Start()
    {
        
        DateTime currentDate = DateTime.Now;

       
        string dateKey = currentDate.ToString("MM-dd");

        
        switch (dateKey)
        {
            case "01-01": 
                SceneManager.LoadScene("NewYearScene");
                break;
            case "02-14": 
                SceneManager.LoadScene("ValentineScene");
                break;
            case "12-24": 
                SceneManager.LoadScene("ChristmasScene");
                break;
           
        }
    }
}
