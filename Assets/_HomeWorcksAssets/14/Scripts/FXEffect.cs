using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXEffect : MonoBehaviour
{
    [SerializeField] private float _timeDestroy;

    private void Start()
    {
        Destroy(gameObject, _timeDestroy);
    }
}
