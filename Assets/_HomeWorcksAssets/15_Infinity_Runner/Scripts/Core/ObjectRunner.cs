using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectRunner : MonoBehaviour
{
    protected virtual void Die()
    {
        gameObject.SetActive(false);
    }
}
