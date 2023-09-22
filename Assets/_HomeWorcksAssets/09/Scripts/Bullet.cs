using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _timeDestroy; 
    private void Start()
    {
        Destroy(this.gameObject, _timeDestroy);
    }
}
