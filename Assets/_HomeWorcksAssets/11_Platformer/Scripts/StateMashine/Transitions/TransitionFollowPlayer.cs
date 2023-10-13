using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionFollowPlayer : Transition
{
    [SerializeField] private float _rayDistance = 5f;
    [SerializeField] private float _rayOffsetY = 0.5f;
    [SerializeField] private LayerMask _layerMask;

    private void FixedUpdate()
    {
        Vector3 rayDirection = transform.rotation * Vector3.right;
        Vector2 rayPosition = new Vector2(transform.position.x, transform.position.y + _rayOffsetY);

        RaycastHit2D hit = Physics2D.Raycast(rayPosition, rayDirection, _rayDistance, _layerMask);
        Debug.DrawRay(rayPosition, rayDirection, Color.red);

        if(hit.collider!=null)
            if (hit.collider.TryGetComponent(out PlayerPlatformer player))
                NeedTransit = true;
    }
}
