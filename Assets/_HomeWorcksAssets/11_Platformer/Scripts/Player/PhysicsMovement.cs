using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(PlayerPlatformer))]
public class PhysicsMovement : MonoBehaviour
{
    private const string InputHorizontalDirection = "Horizontal";

    [SerializeField] private float _minGroundNormalY = .65f;
    [SerializeField] private float _gravityModifier = 1f;
    [SerializeField] private float _jumpForceY = 8f;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private LayerMask _layerMask;

    protected Vector2 Direction;
    protected Vector2 InputDirectionX;
    protected Vector2 GroundNormal;
    protected bool IsGround;
    protected Rigidbody2D Rigidbody2D;
    protected Animator Animator;
    protected SpriteRenderer SpriteRenderer;
    protected ContactFilter2D ContactFilter;
    protected RaycastHit2D[] HitBuffer = new RaycastHit2D[16];
    protected List<RaycastHit2D> HitBufferList = new List<RaycastHit2D>(16);

    protected const float MinMoveDistance = 0.001f;
    protected const float ShellRadius = 0.01f;

    private PlayerPlatformer _player;

    private void OnEnable()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        _player = GetComponent<PlayerPlatformer>();
    }

    private void Start()
    {
        ContactFilter.useTriggers = false;
        ContactFilter.SetLayerMask(_layerMask);
        ContactFilter.useLayerMask = true;
    }

    private void Update()
    {
        if (_player.IsDead())
            return;

        InputDirectionX = new Vector2(Input.GetAxis(InputHorizontalDirection), 0);

        if (InputDirectionX != Vector2.zero)
            ChangeAnimation();

        if (Input.GetKey(KeyCode.Space) && IsGround)
        {
            Direction.y = _jumpForceY;
            Animator.SetTrigger(AnimationData.Params.Jump);
        }
    }

    private void FixedUpdate()
    {
        if (_player.IsDead())
            return;

        Direction += _gravityModifier * Physics2D.gravity * Time.deltaTime;
        Direction.x = InputDirectionX.x;

        IsGround = false;

        Vector2 deltaPosition = Direction * _speed * Time.deltaTime;
        Vector2 moveAlongGround = new Vector2(GroundNormal.y, -GroundNormal.x);
        Vector2 move = moveAlongGround * deltaPosition.x;

        Move(move, false);

        move = Vector2.up * deltaPosition.y;

        Move(move, true);
    }

    private void Move(Vector2 move, bool yMovement)
    {
        float distance = move.magnitude;

        if (distance > MinMoveDistance)
        {
            int count = Rigidbody2D.Cast(move, ContactFilter, HitBuffer, distance + ShellRadius);

            HitBufferList.Clear();

            for (int i = 0; i < count; i++)
            {
                HitBufferList.Add(HitBuffer[i]);
            }

            for (int i = 0; i < HitBufferList.Count; i++)
            {
                Vector2 currentNormal = HitBufferList[i].normal;
                if (currentNormal.y > _minGroundNormalY)
                {
                    IsGround = true;
                    if (yMovement)
                    {
                        GroundNormal = currentNormal;
                        currentNormal.x = 0;
                    }
                }

                float projection = Vector2.Dot(Direction, currentNormal);
                if (projection < 0)
                {
                    Direction = Direction - projection * currentNormal;
                }

                float modifiedDistance = HitBufferList[i].distance - ShellRadius;
                distance = modifiedDistance < distance ? modifiedDistance : distance;
            }
        }

        Rigidbody2D.position = Rigidbody2D.position + move.normalized * distance;
    }

    private void ChangeAnimation()
    {
        if (InputDirectionX.magnitude > 0.1f)
            Animator.SetBool(AnimationData.Params.IsRun, true);
        else
            Animator.SetBool(AnimationData.Params.IsRun, false);

        ChengeRotationY();
    }

    private void ChengeRotationY()
    {
        const float AngleRotation = 180f;

        Quaternion targetRotation;

        if (InputDirectionX.x < 0 && transform.rotation.y != AngleRotation)
        {
            targetRotation = Quaternion.Euler(new Vector3(0, AngleRotation, 0));
            transform.rotation = targetRotation;
        }
        else if (InputDirectionX.x > 0 && transform.rotation.y != 0)
        {
            targetRotation = Quaternion.Euler(Vector3.zero);
            transform.rotation = targetRotation;
        }
    }
}