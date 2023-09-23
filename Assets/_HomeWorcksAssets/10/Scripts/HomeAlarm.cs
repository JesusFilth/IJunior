using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class HomeAlarm : MonoBehaviour
{
    [SerializeField] private float _volumeMaxDelta = 0.2f;

    private AudioSource _audioSource;
    private bool _isPlay;

    private void OnEnable()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        ChangeSignalVolume();
    }

    private void ChangeSignalVolume()
    {
        if (_isPlay)
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _audioSource.maxDistance, _volumeMaxDelta * Time.deltaTime);
        else
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _audioSource.minDistance, (_volumeMaxDelta * -1) * Time.deltaTime);
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
