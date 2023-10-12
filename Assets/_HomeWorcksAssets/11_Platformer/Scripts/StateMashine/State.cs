using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    [SerializeField] private List<Transition> _transition;

    protected PlayerPlatformer PlayerTarget { get; private set; }

    public void Enter(PlayerPlatformer target)
    {
        if (enabled == false)
        {
            PlayerTarget = target;
            enabled = true;

            foreach (var transit in _transition)
            {
                transit.enabled = true;
                transit.Init(target);
            }
        }
    }

    public void Exit()
    {
        if (enabled)
        {
            foreach (var transit in _transition)
                transit.enabled = false;

            enabled = false;
        }
    }

    public State GetNextState()
    {
        foreach (var transit in _transition)
        {
            if (transit.NeedTransit)
                return transit.TargetState;
        }

        return null;
    }
}
