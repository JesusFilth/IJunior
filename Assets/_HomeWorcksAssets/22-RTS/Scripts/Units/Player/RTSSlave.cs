using RTS;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.YamlDotNet.Core.Tokens;
using UnityEngine;

public class RTSSlave : RTSUnit
{
    [SerializeField] private Transform _mineralInHandParent;
    [SerializeField] private Vector3 _handMineralPosition;
    [SerializeField] private Quaternion _handMineralRotation;

    public RTSConstructionBuildingLabel LabelBuildBuilding { get; private set; }

    private void Start()
    {
        IsFree = true;
    }

    public RTSMineralBox CurrentMineral { get; private set; }
    public Transform CurrentTarget { get; private set; }
    public bool IsFree { get; private set; }
    public bool IsBusy { get; private set; }
    public bool IsCarry { get; private set; }

    public bool IsHasCurrentMineral() => CurrentMineral != null;
    public bool IsHasMainBase() => Building != null;
    public bool SetBusy(bool value) => IsBusy = value;
    public bool ToWork() => IsFree = false;
    public RTSMineralBox GetCurrentMineral() => CurrentMineral;

    public void ToFree()
    {
        IsFree = true;
        CurrentMineral = null;
        CurrentTarget = null;
        LabelBuildBuilding = null;
        IsCarry = false;
    }

    public void ToCollictionMineral(RTSMineralBox currentMineral)
    {
        IsFree = false;
        CurrentMineral = currentMineral;
        CurrentTarget = currentMineral.gameObject.transform;
    }

    public void ToBuildBuilding(RTSConstructionBuildingLabel labelBuilding)
    {
        IsFree = false;
        LabelBuildBuilding = labelBuilding;
        CurrentTarget = labelBuilding.gameObject.transform;
    }

    public void PickUpMineral()
    {
        if (CurrentMineral == null || _mineralInHandParent == null)
            return;

        CurrentMineral.transform.parent = _mineralInHandParent;
        CurrentMineral.transform.localPosition = _handMineralPosition;
        CurrentMineral.transform.localRotation = _handMineralRotation;

        RTSMainBase mainBase = Building as RTSMainBase;

        if (mainBase == null)
            return;

        CurrentTarget = mainBase.PutOnMineralPoint;
        IsCarry = true;
    }

    public void PutOnMineral()
    {
        RTSMainBase mainBase = Building as RTSMainBase;

        if (mainBase == null)
            return;

        mainBase.AddMineral(CurrentMineral);
    }

    public void ToBuildBuilding()
    {
        if (LabelBuildBuilding == null)
            return;

        RTSMainBase mainBase = Building as RTSMainBase;

        if (mainBase == null)
            return;

        mainBase.ToBuildBuildingLabel();
    }
}
