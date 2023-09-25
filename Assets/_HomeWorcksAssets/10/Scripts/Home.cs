using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;

    private void OnTriggerEnter(Collider other)
    {
        if (_alarm != null)
            if (other.GetComponent<Thief>() != null)
                _alarm.On();
    }

    private void OnTriggerExit(Collider other)
    {
        if (_alarm != null)
            if (other.GetComponent<Thief>() != null)
                _alarm.Off();
    }
}
