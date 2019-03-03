using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour, IResettable, IActivatable
{
    [SerializeField]
    private Rigidbody2D rb2D;
    [SerializeField]
    private LRSides movementDirection;
    [SerializeField]
    private float startSpeed = 1;
    [SerializeField]
    private ActivationZone activationZone;
    private Vector3 startPosition;

    public bool Activated {get; set;} = false;

    private void Awake()
    {
        if (rb2D == null)
        {
            var foundRb2D = GetComponentInChildren<Rigidbody2D>();
            if (foundRb2D != null)
            {
                rb2D = foundRb2D;
            }
            else Debug.LogError("rigidbody2D not found!");
        }
        startPosition = transform.position;
        activationZone.AddActivatable(this);
    }

    private void Update()
    {
        if (Activated)
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
 
    public void Activate()
    {
        gameObject.SetActive(true);
        Activated = true;
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
        Activated = false;
    }
}
