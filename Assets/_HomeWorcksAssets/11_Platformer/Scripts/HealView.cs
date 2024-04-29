using Assets._HomeWorcksAssets._11_Platformer.Scripts;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealView : MonoBehaviour
{
    [SerializeField] private Image _healFilling;
    [SerializeField] private Stat _heal;
    [SerializeField] private float _maxDeltaChange = 0.07f;

    private IEnumerator _changingHealsBarView;
    private float _targePercentValue = 0;

    private void OnEnable()
    {
        try
        {
            Validate();
        }
        catch (Exception ex) 
        {
            enabled = false;
            throw ex;
        }

        _heal.HealthChanged += ChangeValue;
        _heal.Died += Hide;
    }

    private void OnDisable()
    {
        _heal.HealthChanged -= ChangeValue;
        _heal.Died -= Hide;

        if(_changingHealsBarView != null)
            StopCoroutine(_changingHealsBarView);
    }

    private void Validate()
    {
        if (_healFilling == null)
            throw new ArgumentNullException(nameof(_healFilling));

        if (_heal == null)
            throw new ArgumentNullException(nameof(_heal));
    }

    private void ChangeValue(float valuePercent)
    {
        _targePercentValue = valuePercent;

        if (_changingHealsBarView == null)
        {
            _changingHealsBarView = ChangingTargetValue();
            StartCoroutine(_changingHealsBarView);
        }
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private IEnumerator ChangingTargetValue()
    {
        while (_healFilling.fillAmount != _targePercentValue)
        {
            _healFilling.fillAmount = Mathf.MoveTowards(_healFilling.fillAmount, _targePercentValue, _maxDeltaChange);
            yield return null;
        }

        _changingHealsBarView = null;
    }
}
