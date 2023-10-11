using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerTerminator : MonoBehaviour
{
    [SerializeField] private int _health;

    private int _point;

    public UnityAction<int> HealthChanged;
    public UnityAction<int> PointChanged;
    public UnityAction Died;

    private void Start()
    {
        HealthChanged?.Invoke(_health);
        PointChanged?.Invoke(_point);
    }

    public void TakeDamage(int damage)
    {
        _health = Mathf.Clamp(_health-=damage, 0, int.MaxValue);
        HealthChanged?.Invoke(_health);

        if (_health == 0)
            Die();
    }

    public void AddPoint()
    {
        _point++;
        PointChanged?.Invoke(_point);
    }

    private void Die()
    {
        Died?.Invoke();
    }
}
