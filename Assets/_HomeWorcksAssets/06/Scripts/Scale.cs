using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{
    [SerializeField] private float _speedScale;

    private void Update()
    {
        transform.localScale = transform.localScale + (Vector3.one * _speedScale * Time.deltaTime);
    }
}
