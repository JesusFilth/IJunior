using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMovement2D : MonoBehaviour
{
    private const string InputHorizontalDirection = "Horizontal";

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private bool _isJump;

    private void OnEnable()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis(InputHorizontalDirection);

        Vector2 direction = new Vector2(horizontalInput * _speed, _rigidbody.velocity.y);

        if (direction.magnitude > 0.1f)
        {
            _rigidbody.velocity = new Vector2(horizontalInput * _speed, _rigidbody.velocity.y);
            _spriteRenderer.flipX = horizontalInput < 0;
            _animator.SetBool(AnimatorData.Params.IsRun,true);
        }
        else
        {
            _animator.SetBool(AnimatorData.Params.IsRun, false);
        }

        if (Input.GetKey(KeyCode.Space) && !_isJump)
        {
            _rigidbody.AddForce(new Vector2(0f, _jumpForce), ForceMode2D.Impulse);
            _isJump = true;
            _animator.SetTrigger(AnimatorData.Params.Jump);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out Rigidbody2D rigidbody))
            _isJump = false;
    }

    private class AnimatorData
    {
        public class Params
        {
            public static int IsRun = Animator.StringToHash(nameof(IsRun));
            public static int Jump = Animator.StringToHash(nameof(Jump));
        }
    }
}
