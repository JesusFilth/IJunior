using UnityEngine;

public class RTSStateMashine : MonoBehaviour
{
    [SerializeField] private RTSState _firstState;

    private RTSState _currentState;

    public RTSState CurrentState => _currentState;

    private void Start()
    {
        Reset(_firstState);
    }

    private void Update()
    {
        if (_currentState == null)
            return;

        RTSState nextState = _currentState.GetNextState();

        if (nextState != null)
            Transit(nextState);
    }

    private void Reset(RTSState state)
    {
        if(state==null)
            return;

        _currentState = state;
        _currentState.Enter();
    }

    private void Transit(RTSState nextState)
    {
        if (_currentState != null)
            _currentState.Exit();

        if (nextState == null)
            return;

        _currentState = nextState;
        _currentState.Enter();
    }
}
