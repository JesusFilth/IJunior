using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] float _timeSpawnCoin;
    [SerializeField] bool _isSpawn = true;

    private WaitForSeconds _waitForSeconds;

    private void Start()
    {
        _waitForSeconds = new WaitForSeconds(_timeSpawnCoin);
        StartCoroutine(CoinSpawning());
    }

    private IEnumerator CoinSpawning()
    {
        while (_isSpawn)
        {
            yield return _waitForSeconds;

            Instantiate(_coin, transform.position, Quaternion.identity);
        }
    }
}
