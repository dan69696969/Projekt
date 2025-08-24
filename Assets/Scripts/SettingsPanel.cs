using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{
    private Slider volumeSlider;

    private void Start()
    {
        volumeSlider = GetComponent<Slider>();

        if (volumeSlider != null)
        {
            volumeSlider.value = AudioManager.Instance.GetVolume();

            volumeSlider.onValueChanged.RemoveAllListeners();

            volumeSlider.onValueChanged.AddListener(AudioManager.Instance.SetVolume);
        }
    }
}
