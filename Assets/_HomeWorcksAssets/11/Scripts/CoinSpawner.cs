using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private float _timeSpawnCoin;

    private void Start()
    {
        StartCoroutine(CoinSpawning());
    }

    private IEnumerator CoinSpawning()
    {
        WaitForSeconds _waitForSeconds = new WaitForSeconds(_timeSpawnCoin);

        while (enabled)
        {
            yield return _waitForSeconds;

            Instantiate(_coin, transform.position, Quaternion.identity);
        }
    }
}
