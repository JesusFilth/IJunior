using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RTSMainBase : MonoBehaviour
{
    [SerializeField] private Transform _boxMineralConteiner;
    [SerializeField] private Transform _slaveUnitConteiner;

    private int _minerals = 0;

    public UnityAction<int> MineralChanged;

    private void Start()
    {
        MineralChanged?.Invoke(_minerals);
    }

    private void Update()
    {
        if(TryGetFreeSlave(out RTSSlave slave))
        {
            if (TryGetFreeMineral(out RTSMineralBox mineralBox))
            {
                mineralBox.SetReservation();
                slave.SetCurrentMineral(mineralBox);
                slave.SetMainBasePosition(transform);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out RTSSlave slave))
        {
            RTSMineralBox tempCurrentMineral = slave.GetCurrentMineral();
            slave.PutOnMineral();

            AddMineral(tempCurrentMineral);
            ResetCurrentMineral(tempCurrentMineral);
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

    private void AddMineral(RTSMineralBox boxMineral)
    {
        _minerals += boxMineral.Count;
        MineralChanged?.Invoke(_minerals);
    }

    private void ResetCurrentMineral(RTSMineralBox boxMineral)
    {
        boxMineral.transform.parent = _boxMineralConteiner;
        boxMineral.transform.rotation = Quaternion.identity;
        boxMineral.SetFree();
    }
}
