using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public AudioSource source;
    public Slider volumeSlider;
    void Start()
    {
        if (volumeSlider != null)
        {   
            volumeSlider.value = AudioManager.Instance.GetVolume();
            volumeSlider.onValueChanged.AddListener(AudioManager.Instance.SetVolume);
        }
    }

    public void SetVolume(float volume)
    {
        if(source != null)
        {
            source.volume = volume;
        }
    }
}
