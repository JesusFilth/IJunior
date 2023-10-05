using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyRunnerSpawner))]
public class LevelRunnerDifficult : MonoBehaviour
{
    [SerializeField] private PlayerRunner _player;
    [SerializeField] private float _delayRise = 0.1f;
    [SerializeField] private int _pointNeedToRise = 1;

    private EnemyRunnerSpawner _spawner;

    private void OnEnable()
    {
        _spawner = GetComponent<EnemyRunnerSpawner>();

        if (_player != null)
            _player.PointChanged += ChangePoint;
    }

    private void OnDisable()
    {
        if (_player != null)
            _player.PointChanged -= ChangePoint;
    }

    private void ChangePoint(int point)
    {
        if (point % _pointNeedToRise == 0)
            _spawner.AddDelay(-_delayRise);
    }
}
