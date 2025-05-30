using UnityEngine;
using UnityEngine.UI;

public class MusicVolume : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource audioSource;

    void Start()
    {
        volumeSlider.value = audioSource.volume;
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
    }

    void OnVolumeChanged(float value)
    {
        audioSource.volume = value;
    }
}
