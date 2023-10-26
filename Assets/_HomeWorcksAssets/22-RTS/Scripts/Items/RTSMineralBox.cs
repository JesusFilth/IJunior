using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSMineralBox : MonoBehaviour
{
    public bool HasSlave { get; private set; }

    public void SetReservation()
    {
        HasSlave = true;
    }

    public void SetFree()
    {
        HasSlave = false;
        gameObject.SetActive(false);
    }
}
