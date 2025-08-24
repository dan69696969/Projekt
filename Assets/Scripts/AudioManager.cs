using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    private float volume = 1f;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        // auto sync after each scene load
        SceneManager.sceneLoaded += (scene, mode) => ApplyVolumeToAll();
    }

    public void SetVolume(float value)
    {
        volume = value;
        ApplyVolumeToAll();
    }

    public float GetVolume() => volume;

    private void ApplyVolumeToAll()
    {
        AudioSource[] sources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource src in sources)
            src.volume = volume;
    }
}
