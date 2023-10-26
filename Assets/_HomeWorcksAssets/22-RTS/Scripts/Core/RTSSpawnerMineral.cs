using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RTSPoolMineral))]
public class RTSSpawnerMineral : MonoBehaviour
{
    [SerializeField] float _delay;
    [SerializeField] float _positionY = 0;

    [Space]
    [SerializeField] private Transform _startPerimeter;
    [SerializeField] private Transform _endPerimeter;
    [Space]
    [SerializeField] private Transform _startBuildPerimeter;
    [SerializeField] private Transform _endBuildPerimeter;

    private IEnumerator _creating;
    private RTSPoolMineral _pool;

    private void OnEnable()
    {
        _pool = GetComponent<RTSPoolMineral>();

        if (_creating == null)
            _creating = Creating();

        StartCoroutine(_creating);
    }

    private void OnDisable()
    {
        if (_creating != null)
        {
            StopCoroutine(_creating);
            _creating = null;
        }
    }

    private IEnumerator Creating()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_delay);

        while (enabled)
        {
            _pool.CreateObject(GetRandomPosition());

            yield return waitForSeconds;
        }

        _creating = null;
    }

    private Vector3 GetRandomPosition()
    {
        float positionX = 0;
        float positionZ = 0;

        bool flag = true;

        while (flag)
        {
            positionX = Random.Range(_startPerimeter.position.x, _endPerimeter.position.x);
            positionZ = Random.Range(_startPerimeter.position.z, _endPerimeter.position.z);

            if (CheckPosition(positionX, positionZ))
                flag = false;
        }

        return new Vector3(positionX, _positionY, positionZ);
    }

    private bool CheckPosition(float positionX, float positionZ)
    {
        if (positionX >= _startBuildPerimeter.position.x
            && positionX <= _endBuildPerimeter.position.x
            && positionZ >= _startBuildPerimeter.position.z
            && positionZ <= _endBuildPerimeter.position.z)
        {
            return false;
        }

        return true;
    }
}
