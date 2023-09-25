using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private float _volumeMaxDelta = 0.2f;

    private AudioSource _audioSource;

    private float _minVolume = 0;
    private float _maxVolume = 1;
    private IEnumerator _currentSignalCoroutine;

    private void OnEnable()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private IEnumerator ChangeSignalVolume(float conditionVolume, float toDistanceVolume, float deltaVolume)
    {
        while (_audioSource.volume != conditionVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, toDistanceVolume, deltaVolume * Time.deltaTime);

            yield return null;
        }
    }

    private IEnumerator IncreasingSignal()
    {
        if (_audioSource.isPlaying == false)
            _audioSource.Play();

        yield return ChangeSignalVolume(_maxVolume, _audioSource.maxDistance, _volumeMaxDelta);
    }

    private IEnumerator DecreasingSignal()
    {
        yield return ChangeSignalVolume(_minVolume, _audioSource.minDistance, (_volumeMaxDelta * -1));

        _audioSource.Stop();
    }

    public void On()
    {
        StartSignalCoroutine(IncreasingSignal());
    }

    public void Off()
    {
        StartSignalCoroutine(DecreasingSignal());
    }

    private void StartSignalCoroutine(IEnumerator signalCourotine)
    {
        if (_currentSignalCoroutine != null)
            StopCoroutine(_currentSignalCoroutine);

        _currentSignalCoroutine = signalCourotine;
        StartCoroutine(_currentSignalCoroutine);
    }
}
