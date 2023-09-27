using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DORotate : MonoBehaviour
{
    [SerializeField] private Vector3 _targetRotation;
    [SerializeField] private float _timeRotate;

    private void Start()
    {
        transform.DORotate(_targetRotation, _timeRotate).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
    }
}
