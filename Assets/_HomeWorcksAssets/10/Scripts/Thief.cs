using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class Thief : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;
    private Animator _animator;

    private void OnEnable()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput).normalized;

        if (direction != Vector3.zero)
        {
            _rigidbody.velocity = direction * _speed;
            _animator.SetBool(AnimatorData.Params.IsWalk, true);

            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 360f * Time.deltaTime);
        }
        else
        {
            _animator.SetBool(AnimatorData.Params.IsWalk, false);
        }
    }

    public static class AnimatorData
    {
        public static class Params
        {
            public static int IsWalk = Animator.StringToHash(nameof(IsWalk));
        }
    }
}