using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private Slider _healthBar;
    [SerializeField] private float _maxDeltaChangeHealhBar;

    private float _health;

    public void GetHit(float damage)
    {
        _health -= damage;

        if (_health < 0)
            _health = 0;

        ChangeHealthBar();
    }

    public void GetHeal(float heal)
    {
        _health += heal;

        if (_health > _maxHealth)
            _health = _maxHealth;

        ChangeHealthBar();
    }

    private void Start()
    {
        _health = _maxHealth;
    }

    private void OnValidate()
    {
        if (_maxHealth < 0)
            _maxHealth = 0;
    }

    private void ChangeHealthBar()
    {
        const float MaxPercent = 100;

        float healthPercent = MaxPercent / (_maxHealth / _health);

        StartCoroutine(ChangingHealsBarView(healthPercent));
    }

    private IEnumerator ChangingHealsBarView(float healthPercent)
    {
        while (_healthBar.value != healthPercent)
        {
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, healthPercent, _maxDeltaChangeHealhBar);

            yield return null;
        }
    }
}
