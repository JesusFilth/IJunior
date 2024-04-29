using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldRotationUI : MonoBehaviour
{
    [SerializeField] private Quaternion _worldRotation;

    void Update()
    {
        transform.rotation = _worldRotation;
    }
}
