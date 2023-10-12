using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aid : MonoBehaviour
{
    [SerializeField] private int _heal;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out PlayerPlatformer player))
        {
            player.TakeHeal(_heal);
            Destroy(gameObject);
        }
    }
}
