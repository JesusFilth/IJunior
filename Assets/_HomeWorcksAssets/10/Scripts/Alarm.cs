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
    private IEnumerator _currentCoroutine;

    private void OnEnable()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private IEnumerator IncreasingSignal()
    {
        if (_audioSource.isPlaying == false)
            _audioSource.Play();

        while (_audioSource.volume != _maxVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _audioSource.maxDistance, _volumeMaxDelta * Time.deltaTime);

            yield return null;
        }
    }

    private IEnumerator DecreasingSignal()
    {
        while (_audioSource.volume != _minVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _audioSource.minDistance, (_volumeMaxDelta * -1) * Time.deltaTime);

            yield return null;
        }

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
        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);

        _currentCoroutine = signalCourotine;
        StartCoroutine(_currentCoroutine);
    }
}
