using RTS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RTSMainBase : RTSBuilding
{
    [SerializeField] private Transform _boxMineralConteiner;
    [SerializeField] private Transform _mineralConteiner;
    [Space]
    [SerializeField] private RTSPoolMineral _boxMineralPool;
    [SerializeField] private RTSSpawnerMineral _mineralSpawner;
    [Space]
    [SerializeField] private Transform _slaveUnitConteiner;
    [SerializeField] private Transform _harvesterUnitConteiner;
    [Space]
    [SerializeField] private Transform _putOnMineralPoint;

    public Transform PutOnMineralPoint => _putOnMineralPoint;
    public Transform BoxMineralConteiner => _boxMineralConteiner;
    public Transform MineralConteiner => _mineralConteiner;

    private void Update()
    {
        if(TryGetFreeSlave(out RTSSlave slave))
        {
            if (TryGetFreeMineral(out RTSMineralBox mineralBox))
            {
                mineralBox.SetReservation();
                slave.SetCurrentMineral(mineralBox);
                slave.SetMainBase(this);
            }
        }
    }

    public override void Init(RTSGameStats stats)
    {
        base.Init(stats);
        _mineralSpawner.gameObject.SetActive(true);
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