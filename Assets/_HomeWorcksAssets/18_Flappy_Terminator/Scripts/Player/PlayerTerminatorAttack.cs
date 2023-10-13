using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTerminatorAttack : MonoBehaviour
{
    [SerializeField] private BulletTerminator _bullet;
    [SerializeField] private float _bulletOffsetX;

    public void Shot()
    {
        Instantiate(_bullet, 
            new Vector3(transform.position.x + _bulletOffsetX, transform.position.y, transform.position.z), 
            Quaternion.identity);
    }
}
