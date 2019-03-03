using UnityEngine;

namespace RSGPlatformer.Game.World
{
    /// <summary>
    /// A class to define jumping behaviour.
    /// </summary>
    public class Jumper
    {
        protected Rigidbody2D rb2D { get; }
        protected float jumpForce { get; }
        public Jumper(Rigidbody2D rb2D, float initialJumpForce)
        {
            this.rb2D = rb2D;
            jumpForce = initialJumpForce;
        }

        public void Jump()
        {
            rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}