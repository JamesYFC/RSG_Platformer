using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour, IResettable
{
    private enum LRSides {left = -1, right = 1}
    [SerializeField]
    private Rigidbody2D rb2D;
    [SerializeField]
    private LRSides movementDirection;
    [SerializeField]
    private float startSpeed = 1;
    private Vector3 startPosition;

    private void Awake()
    {
        startPosition = transform.position;
    }

    private void FixedUpdate()
    {
        SetVelocity();
    }

    private void SetVelocity()
    {
        rb2D.velocity = new Vector2((int)movementDirection * startSpeed, rb2D.velocity.y);
    }

    public void ResetState()
    {
        transform.position = startPosition;
        rb2D.velocity = Vector2.zero;
    }

}
