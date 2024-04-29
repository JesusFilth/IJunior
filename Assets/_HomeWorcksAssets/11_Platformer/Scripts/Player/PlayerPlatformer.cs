using Assets._HomeWorcksAssets._11_Platformer.Scripts;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Health))]
public class PlayerPlatformer : MonoBehaviour
{
    public event UnityAction Died;

    private Animator _animator;
    private Health _health;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        _health.Died += Die;
    }

    private void OnDisable()
    {
        _health.Died -= Die;
    }

    public bool IsDead()
    {
        return _health.IsDead;
    }

    private void Die()
    {
        _animator.SetTrigger(AnimationData.Params.Dead);
        Died?.Invoke();
    }
}
