using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionAttackOutLook : Transition
{
    [SerializeField] private float _rayAttackDistance = 2f;
    [SerializeField] private float _rayOffsetY = 0.5f;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _delay;

    private IEnumerator _delayBeforeNextTransit;

    private void FixedUpdate()
    {
        Vector3 rayDirection = transform.rotation * Vector3.right;
        Vector2 rayPosition = new Vector2(transform.position.x, transform.position.y + _rayOffsetY);

        RaycastHit2D hit = Physics2D.Raycast(rayPosition, rayDirection, _rayAttackDistance, _layerMask);

        if (hit.collider == null || hit.collider.TryGetComponent(out PlayerPlatformer player) == false)
        {
            if (_delayBeforeNextTransit == null)
                _delayBeforeNextTransit = DelayBeforeNextTransit();

            StartCoroutine(_delayBeforeNextTransit);
        }
    }

    private IEnumerator DelayBeforeNextTransit()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_delay);

        yield return waitForSeconds;

        NeedTransit = true;
        _delayBeforeNextTransit = null;
    }
}
