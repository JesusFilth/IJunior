using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSTransition : MonoBehaviour
{
    [SerializeField] private RTSState _targetState;

    public RTSState TargetState => _targetState;
    public bool NeedTransit { get; protected set; }

    private void OnEnable()
    {
        NeedTransit = false;
    }
}
