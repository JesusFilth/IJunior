using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBarView : MonoBehaviour
{
    const float MaxPercent = 100;

    [SerializeField] private float _maxDeltaChange;

    private Slider _slider;

    private void OnEnable()
    {
        _slider = GetComponent<Slider>();
    }

    public void UpdateVolume(float currentValue, float maxValue)
    {
        float healthPercent = MaxPercent / (maxValue / currentValue);

        StartCoroutine(ChangingHealsBarView(healthPercent));
    }

    private IEnumerator ChangingHealsBarView(float healthPercent)
    {
        while (_slider.value != healthPercent)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, healthPercent, _maxDeltaChange);

            yield return null;
        }
    }
}
