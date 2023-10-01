using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBarView : MonoBehaviour
{
    [SerializeField] private float _maxDeltaChange;
    [SerializeField] public HealthModel _healthModel;

    private Slider _slider;
    private IEnumerator _changingHealsBarView;
    private float _targePercentValue = 0;

    private void OnEnable()
    {
        _slider = GetComponent<Slider>();

        if (_healthModel != null)
            _healthModel.ValueChanged += UpdateVolume;
    }

    private void OnDisable()
    {
        if (_healthModel != null)
            _healthModel.ValueChanged -= UpdateVolume;
    }

    private void UpdateVolume(float percentValue)
    {
        if (_healthModel != null)
            _targePercentValue = percentValue;

        if (_changingHealsBarView == null)
        {
            _changingHealsBarView = ChangingTargetValue();
            StartCoroutine(_changingHealsBarView);
        }
    }

    private IEnumerator ChangingTargetValue()
    {
        while (_slider.value != _targePercentValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _targePercentValue, _maxDeltaChange);

            yield return null;
        }

        _changingHealsBarView = null;
    }
}
