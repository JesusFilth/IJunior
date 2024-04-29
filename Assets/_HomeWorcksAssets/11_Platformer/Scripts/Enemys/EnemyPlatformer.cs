using Assets._HomeWorcksAssets._11_Platformer.Scripts;
using UnityEngine;

[RequireComponent(typeof(Stat))]
public class EnemyPlatformer : MonoBehaviour
{
    [SerializeField] private PlayerPlatformer _playerTarget;

    public PlayerPlatformer PlayerTarget => _playerTarget;

    private Stat _stat;

    private void Awake()
    {
        _stat = GetComponent<Stat>();
    }

    public bool IsDead()
    {
        return _stat.IsDead;
    }
}
