using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOMove : MonoBehaviour
{
    [SerializeField] private Vector3 _targetMove;
    [SerializeField] private float _timeMove;

    private void Start()
    {
        transform.DOMove(_targetMove, _timeMove).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }
}
