using Assets._HomeWorcksAssets._11_Platformer.Scripts;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class EnemyPlatformer : MonoBehaviour
{
    [SerializeField] private PlayerPlatformer _playerTarget;

    public PlayerPlatformer PlayerTarget => _playerTarget;

    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    public bool IsDead()
    {
        return _health.IsDead;
    }
}
