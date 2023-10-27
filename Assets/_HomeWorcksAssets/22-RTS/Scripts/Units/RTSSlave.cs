using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.YamlDotNet.Core.Tokens;
using UnityEngine;

public class RTSSlave : MonoBehaviour
{
    [SerializeField] private Transform _mainBasePosition;
    [SerializeField] private Transform _mineralInHandParent;
    [SerializeField] private Vector3 _handMineralPosition;
    [SerializeField] private Quaternion _handMineralRotation;

    private void Start()
    {
        IsFree = true;
    }

    public Transform MainBase => _mainBasePosition;
    public RTSMineralBox CurrentMineral { get; private set; }
    public bool IsFree { get; private set; }
    public bool IsBusy { get; private set; }

    public bool IsHasCurrentMineral() => CurrentMineral != null;
    public bool IsHasMainBase() => _mainBasePosition != null;
    public bool ToFree() => IsFree = true;
    public bool ToWork() => IsFree = false;
    public bool SetBusy(bool value) => IsBusy = value;
    public RTSMineralBox GetCurrentMineral() => CurrentMineral;

    public void SetCurrentMineral(RTSMineralBox currentMineral)
    {
        CurrentMineral = currentMineral;
    }

    public void PickUpMineral()
    {
        CurrentMineral.transform.parent = _mineralInHandParent;
        CurrentMineral.transform.localPosition = _handMineralPosition;
        CurrentMineral.transform.localRotation = _handMineralRotation;
    }
}
