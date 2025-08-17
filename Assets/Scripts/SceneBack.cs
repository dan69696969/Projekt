using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class SceneBack : MonoBehaviour
{
    private static SceneBack instance;
    private static Stack<string> sceneHistory = new Stack<string>();

    private void Awake()
    {
        // Singleton – zajistí, že script bude jen jednou
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void OnEnable()
    {
        // posloucháme změnu scény
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // uložíme jméno scény do historie
        if (sceneHistory.Count == 0 || sceneHistory.Peek() != scene.name)
        {
            sceneHistory.Push(scene.name);
        }
    }

    private void Update()
    {
        // ← šipka = zpět
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GoBack();
        }
    }

    public void GoBack()
    {
        if (sceneHistory.Count > 1) // alespoň 2 scény (aktuální + předchozí)
        {
            // vyhodíme aktuální
            sceneHistory.Pop();
            // načteme předchozí
            string previousScene = sceneHistory.Pop();
            SceneManager.LoadScene(previousScene);
        }
    }
}