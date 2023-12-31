using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speedMove;

    private void Update()
    {
        transform.Translate(transform.forward * _speedMove * Time.deltaTime);
    }
}
