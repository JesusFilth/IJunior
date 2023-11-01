using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSHarvester : MonoBehaviour
{
    [SerializeField] private float _collectionTime = 3f;
    [SerializeField] private float _speed = 3f;
    [SerializeField] private RTSMainBase _mainBase;

    [SerializeField] private ParticleSystem _collectionEffect;

    public float Speed => _speed;
    public float CollectionTime => _collectionTime;

    public RTSMineral CurrentMineral { get; private set; }

    public bool IsHasCurrentMineral() => CurrentMineral != null;

    public void Init(RTSMainBase mainBase)
    {
        _mainBase = mainBase;
    }

    public Transform GetMineralConteiner()
    {
        return _mainBase.MineralConteiner;
    }

    public void SetCurrentMineral(RTSMineral mineral)
    {
        CurrentMineral = mineral;
    }

    public void RecycleMineral()
    {
        if (CurrentMineral == null)
            return;

        _mainBase.CreateBoxMineral(GetCurrentMineralPosition());

        CurrentMineral.gameObject.SetActive(false);
        CurrentMineral = null;
    }

    public void CollectionProcessOn()
    {
       _collectionEffect.transform.position = GetCurrentMineralPosition();
       _collectionEffect.gameObject.SetActive(true);
    }

    public void CollectionProcessOff()
    {
        _collectionEffect.gameObject.SetActive(false);
    }

    private Vector3 GetCurrentMineralPosition() 
    {
        return new Vector3(
            CurrentMineral.transform.position.x,
            CurrentMineral.transform.position.y,
            CurrentMineral.transform.position.z);
    } 
}
