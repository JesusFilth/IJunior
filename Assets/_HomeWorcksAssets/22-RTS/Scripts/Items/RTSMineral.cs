using DG.Tweening;
using UnityEngine;

public class RTSMineral : MonoBehaviour
{
    [SerializeField] private Vector3 _startScale;
    [SerializeField] private Vector3 _targetScale;
    [SerializeField] private float _timeScale;

    private void OnEnable()
    {
        transform.localScale = _startScale;
        transform.DOScale(_targetScale, _timeScale);
    }

    private void OnDisable()
    {
        transform.DOPause();        
    }
}
