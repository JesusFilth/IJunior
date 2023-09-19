using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleTrigger : MonoBehaviour
{
    [SerializeField] private PointEffector2D _pointEffector;
    [SerializeField] private float _forceMagnetude = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
        {
            _pointEffector.forceMagnitude = _forceMagnetude;
        }
    }
}
