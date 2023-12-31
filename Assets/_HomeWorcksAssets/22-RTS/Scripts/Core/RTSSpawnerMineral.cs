using System.Collections;
using UnityEngine;

[RequireComponent(typeof(RTSPoolMineral))]
public class RTSSpawnerMineral : MonoBehaviour
{
    [SerializeField] float _delay;
    [SerializeField] float _positionY = 0;

    [SerializeField] private float _radiusDistance = 70f;
    [SerializeField] private LayerMask _layerMask;

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
            positionX = Random.Range(transform.position.x - _radiusDistance, transform.position.x + _radiusDistance);
            positionZ = Random.Range(transform.position.z - _radiusDistance, transform.position.z + _radiusDistance);

            if (CheckPosition(positionX, positionZ))
                flag = false;
        }

        return new Vector3(positionX, _positionY, positionZ);
    }

    private bool CheckPosition(float positionX, float positionZ)
    {
        float rayDistance = 1.5f;
        float positionY = - 0.5f;
        Vector3 rayPosition = new Vector3(positionX, positionY, positionZ);

        RaycastHit[] hits = Physics.RaycastAll(rayPosition, Vector3.up, rayDistance, _layerMask);

        if (hits.Length != 0)
            return false;

        return true;
    }
}
