using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthGameManager : MonoBehaviour
{
    [SerializeField] private PlayerHealthModel _playerModel;
    [SerializeField] private HealthBarView _healthBarView;

    public void TakeDamage(float damage)
    {
        _playerModel.TakeDamage(damage);
        _healthBarView.UpdateVolume(_playerModel.Health, _playerModel.MaxHealth);
    }

    public void TakeHeal(float heal)
    {
        _playerModel.TakeHeal(heal);
        _healthBarView.UpdateVolume(_playerModel.Health, _playerModel.MaxHealth);
    }
}
