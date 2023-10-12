using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionAttackDistance : Transition
{
    [SerializeField] private float _distance = 1.0f;

    private void Update()
    {
        if (Vector2.Distance(transform.position, PlayerTarget.transform.position) < _distance)
            NeedTransit = true;
    }
}
