using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class DOColor : MonoBehaviour
{
    [SerializeField] private Color _targeColor;
    [SerializeField] private float _timeColor;

    private void Start()
    {
        GetComponent<MeshRenderer>().material.DOColor(_targeColor, _timeColor).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }
}
