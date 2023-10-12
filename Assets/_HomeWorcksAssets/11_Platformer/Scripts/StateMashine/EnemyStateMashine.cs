using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyPlatformer))]
public class EnemyStateMashine : MonoBehaviour
{
    [SerializeField] private State _firstState;

    private PlayerPlatformer _playerTarget;
    private State _currentState;

    public State CurrentState => _currentState;

    private void Start()
    {
        _playerTarget = GetComponent<EnemyPlatformer>().PlayerTarget;
        Reset(_firstState);
    }

    private void Update()
    {
        if (_currentState == null)
            return;

        State nextState = _currentState.GetNextState();

        if (nextState != null)
            Transit(nextState);
    }

    private void Reset(State state)
    {
        if (state == null)
            return;

        _currentState = state;
        _currentState.Enter(_playerTarget);
    }

    private void Transit(State nextState)
    {
        if (_currentState != null)
            _currentState.Exit();

        if (nextState == null)
            return;

        _currentState = nextState;
        _currentState.Enter(_playerTarget);
    }
}
