using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundSilencer : MonoBehaviour
{
    [SerializeField] private Toggle _muteToggle;
    [SerializeField] private AudioMixerGroup _mixerGroup;

    private const float MaxValueVolume = 0;
    private const float MinValueVolume = -80;

    public void ToggleVolume()
    {
        if (_muteToggle.isOn)
        {
            _mixerGroup.audioMixer.SetFloat(_mixerGroup.name, MinValueVolume);
        }
        else
        {
            _mixerGroup.audioMixer.SetFloat(_mixerGroup.name, MaxValueVolume);
        }
    }
}