using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RTSSlaveMovement))]
[RequireComponent(typeof(RTSSlave))]
public class RTSStateSlavePickUpMineral : RTSState
{
    [SerializeField] private float _delay = 2f;

    private RTSSlaveMovement _slaveMovement;
    private RTSSlave _slave;

    private IEnumerator _pickingUp;

    private void OnEnable()
    {
        if (_slaveMovement == null)
            _slaveMovement = GetComponent<RTSSlaveMovement>();

        if (_slave == null)
            _slave = GetComponent<RTSSlave>();

        if (_pickingUp == null)
            _pickingUp = PickingUp();

        StartCoroutine(_pickingUp);
    }

    private void OnDisable()
    {
        if (_pickingUp != null)
        {
            StopCoroutine(_pickingUp);
            _pickingUp = null;
        }
    }

    private IEnumerator PickingUp()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_delay);
        _slave.SetBusy(true);
        _slaveMovement.ToPickUp();

        yield return waitForSeconds;

        _slave.PickUpMineral();
        _slave.SetBusy(false);
        _pickingUp = null;
    }
}
