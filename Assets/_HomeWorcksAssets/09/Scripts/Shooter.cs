using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private float _timeWait;
    [SerializeField] private Rigidbody _bullet;
    [SerializeField] private Transform _shootTarget;

    private WaitForSeconds _waitForSeconds;

    private void Start()
    {
        _waitForSeconds = new WaitForSeconds(_timeWait);

        StartCoroutine(Shooting());
    }

    private IEnumerator Shooting()
    {
        while (enabled)
        {
            Vector3 shootDirection = (_shootTarget.position - transform.position).normalized;
            Rigidbody tempRigibodyBullet = Instantiate(_bullet, transform.position + shootDirection, Quaternion.identity);

            tempRigibodyBullet.transform.up = shootDirection;
            tempRigibodyBullet.velocity = shootDirection * _force;

            yield return _waitForSeconds;
        }
    }
}