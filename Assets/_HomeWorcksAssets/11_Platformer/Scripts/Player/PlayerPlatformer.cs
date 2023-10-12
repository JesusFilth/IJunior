using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class PlayerPlatformer : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _maxHealth = 5;

    public UnityAction Died;

    private Animator _animator;

    private void OnEnable()
    {
        _animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        _health = Mathf.Clamp(_health - damage, 0, int.MaxValue);

        if (_health == 0)
            Die();
    }

    public void TakeHeal(int heal)
    {
        _health = Mathf.Clamp(_health + heal, 0, _maxHealth);
    }

    public bool IsDead()
    {
        return _health <= 0;
    }

    private void Die()
    {
        Debug.Log("Die");
        _animator.SetTrigger(AnimationData.Params.Dead);
        Died?.Invoke();
    }
}
