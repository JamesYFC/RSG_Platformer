using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideMovement : BasicActivatableMovement
{
    [SerializeField]
    private LRSides movementDirection;

    protected virtual void FixedUpdate()
    {
        if (Activated)
            SetVelocity();
    }

    private void SetVelocity()
    {
        rb2D.velocity = new Vector2((int)movementDirection * baseSpeed, rb2D.velocity.y);
    }
 
}
