using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunner : MonoBehaviour
{
    [SerializeField] private int _health = 3;
    [SerializeField] private int _point = 0;

    public event Action<int, bool, bool> HealthChanged;
    public event Action<int> PointChanged;
    public event Action Died;

    private void Start()
    {
        HealthChanged?.Invoke(_health,true,true);
    }

    private void OnValidate()
    {
        _health = Mathf.Clamp(_health, 0, int.MaxValue);
    }

    public void ChangeHealth(int value)
    {
        _health = Mathf.Clamp(_health += value, 0, int.MaxValue);
        HealthChanged?.Invoke(_health, value < 0 ? false : true, false);

        if (_health <= 0)
            Die();
    }

    public void AddPoint(int countPoint)
    {
        _point += countPoint;
        PointChanged?.Invoke(_point);
    }

    private void Die()
    {
        Died?.Invoke();
    }
}
