using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSound : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Slider _sliderMusic;
    private string nameMusicGroup = "Music";

    private void Start()
    {
        Subscribe(_sliderMusic);
        SaveSliderValue(_sliderMusic, nameMusicGroup);
    }
    private void Subscribe(Slider sliderMusic)
    {
        sliderMusic.onValueChanged.AddListener(delegate { Volume(_audioMixer, nameMusicGroup, _sliderMusic); });
    }
    private void Volume(AudioMixer audioMixer, string nameGroup, Slider slider)
    {
        audioMixer.SetFloat(nameGroup, slider.value);
        PlayerPrefs.SetFloat(nameGroup, slider.value);
    }
    private void SaveSliderValue(Slider slider, string name)
    {
        slider.value = PlayerPrefs.GetFloat(name);
    }
}
