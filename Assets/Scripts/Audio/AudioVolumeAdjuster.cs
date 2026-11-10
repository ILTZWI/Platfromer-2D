using UnityEngine;
using UnityEngine.Audio;

public class AudioVolumeAdjuster : MonoBehaviour
{
    private const float MaxValueVolume = 20;
    private const float MinValueVolume = -80f;

    [SerializeField] private AudioMixerGroup _mixerGroup;

    public void ChangeVolume(float volume)
    {
        volume = Mathf.Clamp01(volume);
        float decibels = volume;

        if (volume == 0f)
        {
            decibels = MinValueVolume;
        }
        else
        {
            decibels = Mathf.Log10(volume) * MaxValueVolume;
        }

        _mixerGroup.audioMixer.SetFloat(_mixerGroup.name, decibels);
    }
}