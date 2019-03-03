using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IResettable
{
    [SerializeField]
    private Rigidbody2D rb2D;
    [SerializeField]
    private CapsuleCollider2D coll2D;

    [SerializeField]
    private float baseSpeed;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float superJumpMultiplier = 1.5f;

    [SerializeField]
    private float groundedCheckOffset = 0.1f;
    private enum GroundedStates {None, Ground, BoostGround}
    private GroundedStates groundedState;

    private Vector3 resetPosition;

    private void Awake()
    {
        resetPosition = transform.position;
    }

    private void Update()
    {
        //TODO: make custom inputmanager? so we don't have to type these in as strings all the time in behaviour scripts
        ApplyHorizontalMovement();

        if (Input.GetButtonDown("Jump"))
        {
            groundedState = GroundedCheck();

            switch (groundedState)
            {
                case GroundedStates.Ground:
                    Jump();
                    break;
                case GroundedStates.BoostGround:
                    SuperJump();
                    break;
            }
        }
    }

    private void Jump()
    {
        rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void SuperJump()
    {
        rb2D.AddForce(Vector2.up * jumpForce * superJumpMultiplier, ForceMode2D.Impulse);
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

    public void ResetState()
    {
        rb2D.velocity = Vector2.zero;
        transform.position = resetPosition;
    }
}
