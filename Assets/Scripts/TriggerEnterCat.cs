using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnterCat : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out CatMoving cat))
        {
            cat.ChangDirection();
        }
    }
}
