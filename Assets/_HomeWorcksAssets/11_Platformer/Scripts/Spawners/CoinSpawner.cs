using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private float _delay = 3f;

    private void Start()
    {
        StartCoroutine(CoinSpawning());
    }

    private IEnumerator CoinSpawning()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_delay);

        while (enabled)
        {
            yield return waitForSeconds;

            Instantiate(_coin, transform.position, Quaternion.identity);
        }
    }
}
