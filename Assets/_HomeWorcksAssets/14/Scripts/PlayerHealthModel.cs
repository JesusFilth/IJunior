using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthModel : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    private float _health;

    public float Health => _health;
    public float MaxHealth => _maxHealth;

    public void TakeDamage(float damage)
    {
        _health -= damage;

        if (_health < 0)
            _health = 0;
    }

    public void TakeHeal(float heal)
    {
        _health += heal;

        if (_health > _maxHealth)
            _health = _maxHealth;
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
}
