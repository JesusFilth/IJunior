using Assets._HomeWorcksAssets._11_Platformer.Scripts;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Stat))]
public class PlayerPlatformer : MonoBehaviour
{
    public UnityAction Died;

    private Animator _animator;
    private Stat _stat;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _stat = GetComponent<Stat>();
    }

    private void OnEnable()
    {
        _stat.Died += Die;
    }

    private void OnDisable()
    {
        _stat.Died -= Die;
    }

    public bool IsDead()
    {
        return _stat.IsDead;
    }

    private void Die()
    {
        Debug.Log("Die");
        _animator.SetTrigger(AnimationData.Params.Dead);
        Died?.Invoke();
    }
}
