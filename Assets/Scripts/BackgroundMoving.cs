using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMoving : MonoBehaviour
{
    [SerializeField] private Transform _camera;

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, _camera.position.y,transform.position.z);
    }
}
