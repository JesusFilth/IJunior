using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float _speedRotate;

    private void Update()
    {
        transform.Rotate(0, _speedRotate * Time.deltaTime, 0);
    }
}
