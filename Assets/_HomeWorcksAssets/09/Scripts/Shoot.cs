using System.Collections;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private float _timeWait;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _shootTarget;

    [SerializeField] private bool _isWork = true;

    private WaitForSeconds _waitForSeconds;

    private void Start()
    {
        _waitForSeconds = new WaitForSeconds(_timeWait);

        StartCoroutine(ShootWork());
    }

    private IEnumerator ShootWork()
    {
        while (_isWork)
        {
            Vector3 shootDirection = (_shootTarget.position - transform.position).normalized;
            Rigidbody tempRigibodyBullet = Instantiate(_bullet, transform.position + shootDirection, Quaternion.identity).GetComponent<Rigidbody>();

            tempRigibodyBullet.transform.up = shootDirection;
            tempRigibodyBullet.velocity = shootDirection * _force;

            yield return _waitForSeconds;
        }
    }
}