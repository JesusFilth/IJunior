using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(MeshRenderer))]
public class DOTransformer : MonoBehaviour
{
    [SerializeField] private bool _isMove;
    [SerializeField] private bool _isRotate;
    [SerializeField] private bool _isScale;
    [SerializeField] private bool _isColor;

    [SerializeField] private Vector3 _targetMove;
    [SerializeField] private Vector3 _targetRotation;
    [SerializeField] private Vector3 _targetScale;
    [SerializeField] private Color _targeColor;

    [SerializeField] private float _timeMove;
    [SerializeField] private float _timeRotate;
    [SerializeField] private float _timeScale;
    [SerializeField] private float _timeColor;

    void Start()
    {
        if (_isMove)
            transform.DOMove(_targetMove, _timeMove).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);

        if (_isRotate)
            transform.DORotate(_targetRotation, _timeRotate).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);

        if (_isScale)
            transform.DOScale(_targetScale, _timeScale).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);

        if (_isColor)
            GetComponent<MeshRenderer>().material.DOColor(_targeColor, _timeColor).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }
}
