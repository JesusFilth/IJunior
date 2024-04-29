using Assets._HomeWorcksAssets._11_Platformer.Scripts;
using System;
using UnityEngine;
using UnityEngine.UI;

public class HealView : MonoBehaviour
{
    [SerializeField] private Image _healFilling;
    [SerializeField] private Stat _heal;

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
        _healFilling.fillAmount = valuePercent;
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
