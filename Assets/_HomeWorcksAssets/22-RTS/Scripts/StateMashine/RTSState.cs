using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSState : MonoBehaviour
{
    [SerializeField] private List<RTSTransition> _transitions;

    public void Enter()
    {
        if (enabled == false)
        {
            enabled = true;

            foreach (var transition in _transitions)
            {
                transition.enabled = true;
            }
        }
    }

    public void Exit()
    {
        if (enabled)
        {
            foreach (var transition in _transitions)
            {
                transition.enabled = false;
            }

            enabled = false;
        }
    }

    public RTSState GetNextState()
    {
        foreach(var transition in _transitions)
        {
            if (transition.NeedTransit)
                return transition.TargetState;
        }

        return null;
    }
}
