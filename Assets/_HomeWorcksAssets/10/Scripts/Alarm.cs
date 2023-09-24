using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private float _volumeMaxDelta = 0.2f;

    private AudioSource _audioSource;
    private bool _isPlay;

    private float _minVolume = 0;
    private float _maxVolume = 1;

    private void OnEnable()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        ChangeSignalVolume();
        ChangeSignalState();
    }
    private void ChangeSignalVolume()
    {
        if (_isPlay && _audioSource.volume != _maxVolume)
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _audioSource.maxDistance, _volumeMaxDelta * Time.deltaTime);
        else if (_isPlay == false && _audioSource.volume != _minVolume)
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _audioSource.minDistance, (_volumeMaxDelta * -1) * Time.deltaTime);
    }

    private void ChangeSignalState()
    {
        if (_audioSource.volume > _minVolume && _audioSource.isPlaying == false)
            _audioSource.Play();
        else if (_audioSource.volume == _minVolume && _audioSource.isPlaying)
            _audioSource.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Thief>() != null)
            _isPlay = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Thief>() != null)
            _isPlay = false;
    }
}
