using UnityEngine;
public class SuperJumper : Jumper
{
    private float superJumpMultiplier;
    public SuperJumper(Rigidbody2D rb2D, float initialJumpForce, float superJumpMultiplier) : base(rb2D, initialJumpForce)
    {
        this.superJumpMultiplier = superJumpMultiplier; 
    }

    public void SuperJump()
    {
        rb2D.AddForce(Vector2.up * jumpForce * superJumpMultiplier, ForceMode2D.Impulse);
    }
}
