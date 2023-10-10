using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerTerminator : MonoBehaviour
{
    [SerializeField] private int _health;

    private int _point;

    public UnityAction<int> ChangedHealth;
    public UnityAction<int> ChangedPoint;
    public UnityAction Died;

    private void Start()
    {
        ChangedHealth?.Invoke(_health);
        ChangedPoint?.Invoke(_point);
    }

    public void TakeDamage(int damage)
    {
        _health = Mathf.Clamp(_health-=damage, 0, int.MaxValue);
        ChangedHealth?.Invoke(_health);

        if (_health == 0)
            Die();
    }

    public void AddPoint()
    {
        _point++;
        ChangedPoint?.Invoke(_point);
    }

    private void Die()
    {
        Died?.Invoke();
    }
}
