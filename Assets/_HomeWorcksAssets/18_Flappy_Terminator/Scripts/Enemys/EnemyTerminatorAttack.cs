using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTerminatorAttack : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private BulletTerminator _bullet;
    [SerializeField] private float _bulletOffsetX;

    private float _currentTime;

    private void Update()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime >= _delay)
        {
            Instantiate(_bullet,new Vector3(transform.position.x+_bulletOffsetX,transform.position.y,transform.position.z),Quaternion.identity);
            _currentTime = 0;
        }
    }
}
