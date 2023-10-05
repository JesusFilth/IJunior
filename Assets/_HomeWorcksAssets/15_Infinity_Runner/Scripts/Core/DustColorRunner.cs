using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class DustColorRunner : MonoBehaviour
{
    [SerializeField] private Color _targetColor;
    [SerializeField] private int _maxPointForColorEffect;
    [Space]
    [SerializeField] private PlayerRunner _player;

    private ParticleSystem _particle;
    private ParticleSystem.MainModule _particleMainModule;
    private Color _startColor;
    private float _currentPoint;
    private IEnumerator _changing;

    private void OnEnable()
    {
        _particle = GetComponent<ParticleSystem>();
        _particleMainModule = _particle.main;
        _startColor = _particleMainModule.startColor.color;

        if (_player != null)
            _player.PointChanged += Change;
    }

    private void OnDisable()
    {
        if (_player != null)
            _player.PointChanged -= Change;

        if (_changing != null)
        {
            StopCoroutine(_changing);
            _changing = null;
        }
    }

    private void Change(int point)
    {
        _currentPoint = point;

        if (_changing == null && _currentPoint != _maxPointForColorEffect)
        {
            _changing = Changing();
            StartCoroutine(_changing);
        }
    }

    private IEnumerator Changing()
    {
        float colorProgress;

        while (enabled || _currentPoint != _maxPointForColorEffect)
        {
            colorProgress = _currentPoint / _maxPointForColorEffect;
            _particleMainModule.startColor = Color.Lerp(_startColor,_targetColor,colorProgress);

            yield return null;
        }

        _changing = null;
    }
}
