using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Home : MonoBehaviour
{
    [SerializeField] private UnityEvent _enter;
    [SerializeField] private UnityEvent _exit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Thief>() != null)
            _enter?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Thief>() != null)
            _exit?.Invoke();
    }
}
