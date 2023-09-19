using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMoving : MonoBehaviour
{
    [SerializeField] private float speed = 2;
    [SerializeField] private Transform _markStart;
    [SerializeField] private Transform _markFinish;

    [HideInInspector] public bool isForwardRan = true;

    [SerializeField] private SpriteRenderer _spriteRenderer;

    void Update()
    {
        if(isForwardRan)
            transform.position = Vector2.MoveTowards(transform.position, _markFinish.position, speed*Time.deltaTime);
        else
            transform.position = Vector2.MoveTowards(transform.position, _markStart.position, speed*Time.deltaTime);
    }

    public void ChangDirection()
    {
        isForwardRan = !isForwardRan;
        _spriteRenderer.flipX = !_spriteRenderer.flipX;
    }
}
