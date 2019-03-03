using System.Collections;
using UnityEngine;

namespace RSGPlatformer.Game.World
{
    /// <summary>
    /// A type of movement where the object periodically jumps.
    /// </summary>
    public class JumpingEnemyMovement : SideMovement
    {
        [SerializeField]
        private float jumpForce;
        [SerializeField]
        private float jumpInterval;
        private Jumper jumper;

        protected override void Awake()
        {
            base.Awake();
            jumper = new Jumper(rb2D, jumpForce);
        }

        public override void Activate()
        {
            base.Activate();
            StartCoroutine(WaitAndJump());
        }

        private IEnumerator WaitAndJump()
        {
            float startTime = Time.time;
            float currentJumpInterval = jumpInterval;

            yield return new WaitForSeconds(currentJumpInterval);

            if (Activated)
            {
                jumper.Jump();
                StartCoroutine(WaitAndJump());
            }
        }
    }
}