using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyPlatformer))]
public class TransitionDie : Transition
{
    private EnemyPlatformer _enemy;

    private void Start()
    {
        _enemy = GetComponent<EnemyPlatformer>();
    }

    private void Update()
    {
        if (_enemy.IsDead())
            NeedTransit = true;
    }
}
