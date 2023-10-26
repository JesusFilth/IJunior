using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTS
{
    [RequireComponent(typeof(RTSSlaveMovement))]
    public class RTSStateSlavePutOnMineral : RTSState
    {
        private RTSSlaveMovement _slaveMovement;

        private void OnEnable()
        {
            if (_slaveMovement == null)
                _slaveMovement = GetComponent<RTSSlaveMovement>();

            _slaveMovement.ToPickUp();
            //�������� ���� �� ����
            Debug.Log("�������� ���� � ����");
        }
    }
}
