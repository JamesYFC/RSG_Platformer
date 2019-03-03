using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : BasicMovement
{
    [SerializeField]
    private CapsuleCollider2D coll2D;

    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float superJumpMultiplier = 1.5f;
    private SuperJumper superJumper;

    [SerializeField]
    private float groundedCheckOffset = 0.1f;
    private enum GroundedStates {None, Ground, BoostGround}
    private GroundedStates groundedState;

    protected override void Awake()
    {
        base.Awake();
        superJumper = new SuperJumper(rb2D, jumpForce, superJumpMultiplier);
    }

    private void Update()
    {
        ApplyHorizontalMovement();

        if (Input.GetButtonDown("Jump"))
        {
            groundedState = GroundedCheck();

            switch (groundedState)
            {
                case GroundedStates.Ground:
                    superJumper.Jump();
                    break;
                case GroundedStates.BoostGround:
                    superJumper.SuperJump();
                    break;
            }
        }
    }

    private void ApplyHorizontalMovement()
    {
        rb2D.velocity = new Vector2(Input.GetAxis("Horizontal") * baseSpeed, rb2D.velocity.y);
    }

    // return the resulting ground gameobject
    private GroundedStates GroundedCheck()
    {
        // perform a capsule overlap of the same size as the player's collider, but slightly below the player   
        Vector2 capsuleOverlapPoint = new Vector2(coll2D.bounds.center.x, coll2D.bounds.center.y - groundedCheckOffset);
        
        Collider2D result = Physics2D.OverlapCapsule(capsuleOverlapPoint, coll2D.size, coll2D.direction, 0, LayerMask.GetMask("World"));
        
        if (result != null)
        {
            if (result.gameObject.CompareTag("JumpBoost"))
            {
                return GroundedStates.BoostGround;
            }
            else return GroundedStates.Ground;
        }
        else return GroundedStates.None;
    }
    public void SetStartPosition(Vector2 newStartPosition)
    {
        startPosition = newStartPosition;
    }

    public override void ResetState()
    {
        base.ResetState();
        rb2D.velocity = Vector2.zero;
    }
}
