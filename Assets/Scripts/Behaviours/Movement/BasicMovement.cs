using RSGPlatformer.Game.Management;
using UnityEngine;

namespace RSGPlatformer.Game.World
{
    /// <summary>
    /// A base script for movement behaviours.
    /// <summary>
    public abstract class BasicMovement : MonoBehaviour, IResettable
    {
        // return here on reset
        protected Vector2 startPosition { get; set; }
        [SerializeField]
        protected float baseSpeed;
        [SerializeField]
        protected Rigidbody2D rb2D;

        protected virtual void Awake()
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
        }

        public virtual void ResetState()
        {
            transform.position = startPosition;
            rb2D.velocity = Vector2.zero;
        }
    }
}