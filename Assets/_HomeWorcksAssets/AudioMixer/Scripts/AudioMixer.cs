using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioMixer : MonoBehaviour
{
    private const float MaxVolumeLevel = 80f;

    private const string MasterVolume = "MasterVolume";
    private const string EffectsVolume = "EffectsVolume";
    private const string BackgroundMusicVolume = "BackgroundMusicVolume";

    [SerializeField] private AudioMixerGroup _mixer;

    private void OnValidate()
    {
        if (_mixer == null)
            throw new ArgumentNullException(nameof(_mixer));
    }

    public void ToggleMusic(bool isEnabled)
    {
        AudioListener.pause = !isEnabled;
    }

    public void ChangeMasterVolume(float volume)
    {
        _mixer.audioMixer.SetFloat(MasterVolume, Mathf.Log10(volume) * MaxVolumeLevel);
    }

    public void ChangeEffectsVolume(float volume)
    {
        _mixer.audioMixer.SetFloat(EffectsVolume, Mathf.Log10(volume) * MaxVolumeLevel);
    }

    public void ChangeBackgroundMusicVolumeVolume(float volume)
    {
        _mixer.audioMixer.SetFloat(BackgroundMusicVolume, Mathf.Log10(volume) * MaxVolumeLevel);
    }
}
