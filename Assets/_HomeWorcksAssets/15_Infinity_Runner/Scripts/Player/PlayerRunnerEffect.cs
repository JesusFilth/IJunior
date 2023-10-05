using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerRunner))]
public class PlayerRunnerEffect : MonoBehaviour
{
    [SerializeField] private UnityEvent _heal;
    [SerializeField] private UnityEvent _damage;
    [SerializeField] private UnityEvent _point;

    private PlayerRunner _player;

    private void OnEnable()
    {
        _player = GetComponent<PlayerRunner>();
        _player.HealthChanged += ChangeHealth;
        _player.PointChanged += Point;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= ChangeHealth;
        _player.PointChanged -= Point;
    }

    public void ChangeHealth(int value, bool isHealthUp, bool isIgnore)
    {
        if (isIgnore)
            return;

        if (isHealthUp)
            Heal();
        else
            Damage();
    }

    public void Point(int value)
    {
        if (_point == null)
            return;

        _point?.Invoke();
    }

    public void Heal()
    {
        if (_heal == null)
            return;

        _heal?.Invoke();
    }

    public void Damage()
    {
        if (_damage == null)
            return;

        _damage?.Invoke();
    }
}
