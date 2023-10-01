using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthModel : MonoBehaviour
{
    [SerializeField] private float _maxValue;

    public event Action ValueChanged;

    private float _value;

    private void Start()
    {
        _value = _maxValue;
    }

    private void OnValidate()
    {
        _maxValue = Mathf.Clamp(_maxValue, 0f, float.MaxValue);
    }

    public void AddValue(float value)
    {
        _value = Mathf.Clamp(_value += value, 0, _maxValue);

        ValueChanged?.Invoke();
    }

    public float GetPercentValue()
    {
        const float MaxPercent = 100;

        return MaxPercent / (_maxValue / _value);
    }
}
