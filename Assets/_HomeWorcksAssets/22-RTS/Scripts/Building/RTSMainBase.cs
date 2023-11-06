using RTS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RTSMainBase : RTSBuilding
{
    [Space]
    [SerializeField] private Transform _boxMineralConteiner;
    [SerializeField] private Transform _mineralConteiner;
    [SerializeField] private RTSPoolMineral _boxMineralPool;
    [Space]
    [SerializeField] private Transform _slaveUnitConteiner;
    [SerializeField] private Transform _harvesterUnitConteiner;
    [Space]
    [SerializeField] private GameObject _buildingMechanics;
    [Space]
    [SerializeField] private Transform _putOnMineralPoint;
    [SerializeField] private Transform _unitCreatePosition;

    public Transform PutOnMineralPoint => _putOnMineralPoint;
    public Transform BoxMineralConteiner => _boxMineralConteiner;
    public Transform MineralConteiner => _mineralConteiner;

    public RTSConstructionBuildingLabel LabelBuildBuilding { get; private set; }

    private void Update()
    {
        CheckBuildBuilding();
        CheckMineral();
    }

    public override void Init()
    {
        _buildingMechanics.SetActive(true);
        _isActive = true;
    }

    public void SetLabelBuildBuilding(RTSConstructionBuildingLabel labelBuilding)
    {
        LabelBuildBuilding = labelBuilding;
    }

    public void ResetLabelBuilding()
    {
        if (LabelBuildBuilding == null)
            return;

        Destroy(LabelBuildBuilding.gameObject);
        LabelBuildBuilding = null;
    }

    public void SetBuildLabel()
    {
        LabelBuildBuilding.SetLabel();
    }

    public void ToBuildBuildingLabel()
    {
        LabelBuildBuilding.ToBuild();
        LabelBuildBuilding = null;
    }

    public void CreateBoxMineral(Vector3 position)
    {
        if (_boxMineralPool == null)
            return;

        _boxMineralPool.CreateObject(position);
    }

    public void AddMineral(RTSMineralBox boxMineral)
    {
        _gameStats.AddMineral(boxMineral.Count);
        ResetCurrentMineral(boxMineral);
    }

    public void CreateSlave(RTSSlave slavePrefab)
    {
        RTSSlave slave = Instantiate(slavePrefab, _slaveUnitConteiner);
        slave.transform.position = _unitCreatePosition.transform.position;
        slave.Init(this);
    }

    public void AddSleve(RTSSlave slave)
    {
        slave.Init(this);
        slave.transform.parent = _slaveUnitConteiner;
    }

    public void CreteHarvester()
    {

    }

    private void CheckMineral()
    {
        if (TryGetFreeSlave(out RTSSlave slave))
        {
            if (TryGetFreeMineral(out RTSMineralBox mineralBox))
            {
                mineralBox.SetReservation();
                slave.ToCollictionMineral(mineralBox);
            }
        }
    }

    private void CheckBuildBuilding()
    {
        if (LabelBuildBuilding == null)
            return;

        if (LabelBuildBuilding.IsNeedBuild && LabelBuildBuilding.HasSlave == false)
        {
            if (TryGetFreeSlave(out RTSSlave slave))
            {
                slave.ToBuildBuilding(LabelBuildBuilding);
                LabelBuildBuilding.SetReservation();
            }
        }
    }

    private bool TryGetFreeSlave(out RTSSlave slave)
    {
        slave = null;

        if (_slaveUnitConteiner == null)
            return false;

        for (int i = 0; i < _slaveUnitConteiner.childCount; i++)
        {
            if(_slaveUnitConteiner.GetChild(i).TryGetComponent(out RTSSlave freeSlave))
            {
                if (freeSlave.IsFree)
                {
                    slave = freeSlave;
                    return true;
                }
            }
        }

        return false;
    }

    private bool TryGetFreeMineral(out RTSMineralBox mineralBox)
    {
        mineralBox = null;

        if (_boxMineralConteiner == null)
            return false;

        for (int i = 0; i < _boxMineralConteiner.childCount; i++)
        {
            if (_boxMineralConteiner.GetChild(i).gameObject.activeSelf == false)
                continue;

            if(_boxMineralConteiner.GetChild(i).TryGetComponent(out RTSMineralBox freeBox))
            {
                if(freeBox.HasSlave == false)
                {
                    mineralBox = freeBox;
                    return true;
                }
            }
        }

        return false;
    }

    private void ResetCurrentMineral(RTSMineralBox boxMineral)
    {
        boxMineral.transform.parent = _boxMineralConteiner;
        boxMineral.transform.rotation = Quaternion.identity;
        boxMineral.SetFree();
    }
}