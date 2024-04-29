using Assets._HomeWorcksAssets._11_Platformer.Scripts;
using System;
using UnityEngine;
using UnityEngine.UI;

public class HealView : MonoBehaviour
{
    [SerializeField] private Transform _healConteiner;
    [SerializeField] private Stat _heal;
    [SerializeField] private GameObject _healPrefab;

    private void Awake()
    {
        Initialize();
    }

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
    }

    private void OnDisable()
    {
        _heal.HealthChanged -= ChangeValue;
    }

    private void Validate()
    {
        if (_healConteiner == null)
            throw new ArgumentNullException(nameof(_healConteiner));

        if (_heal == null)
            throw new ArgumentNullException(nameof(_heal));

        if (_healPrefab == null)
            throw new ArgumentNullException(nameof(_healPrefab));
    }

    private void Initialize()
    {
        for (int i = 0; i < _heal.MaxHealth; i++)
        {
            Instantiate(_healPrefab ,_healConteiner);
        }
    }

    private void ChangeValue(int value)
    {
        for (int i = 0; i < _healConteiner.childCount; i++)
        {
            _healConteiner.GetChild(i).gameObject.SetActive(value >= (i+1));
        }
    }
}
