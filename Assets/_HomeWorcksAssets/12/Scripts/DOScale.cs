using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOScale : MonoBehaviour
{
    [SerializeField] private Vector3 _targetScale;
    [SerializeField] private float _timeScale;

    private void Start()
    {
        transform.DOScale(_targetScale, _timeScale).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }
}
