using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour, IResettable
{
    [SerializeField]
    private Rigidbody2D rb2D;
    [SerializeField]
    private Vector2 movementDirection;
    [SerializeField]
    private float startSpeed = 1;
    private Vector3 startPosition;

    private void Awake()
    {
        startPosition = transform.position;
    }
    private void Start()
    {
        SetStartVelocity();
    }

    private void SetStartVelocity()
    {
        rb2D.velocity = movementDirection * 1;
    }

    public void ResetState()
    {
        transform.position = startPosition;
        SetStartVelocity();
    }

}
