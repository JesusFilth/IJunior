using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSRodarRotation : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        float rotate = 90f;
        Vector3 newRotation = new Vector3(transform.rotation.x, rotate, transform.rotation.z);
        transform.Rotate(newRotation * _speed * Time.deltaTime);
    }
}
