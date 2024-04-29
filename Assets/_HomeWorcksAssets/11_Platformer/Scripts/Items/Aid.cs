using Assets._HomeWorcksAssets._11_Platformer.Scripts;
using UnityEngine;

public class Aid : MonoBehaviour
{
    [SerializeField] private int _heal;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out Health player))
        {
            player.TakeHeal(_heal);
            Destroy(gameObject);
        }
    }
}
