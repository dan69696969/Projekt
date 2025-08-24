using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{
    private Slider volumeSlider;

    void OnEnable()
    {
        // find slider when panel opens
        volumeSlider = GetComponentInChildren<Slider>(true);

        if (volumeSlider != null)
        {
            // sync slider to saved volume
            volumeSlider.value = AudioManager.Instance.GetVolume();

            // clear old listeners so we don’t stack duplicates
            volumeSlider.onValueChanged.RemoveAllListeners();

            // hook slider to AudioManager
            volumeSlider.onValueChanged.AddListener(AudioManager.Instance.SetVolume);
        }
    }
}
