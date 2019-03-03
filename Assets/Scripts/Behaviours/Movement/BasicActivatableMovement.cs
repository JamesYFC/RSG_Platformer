using UnityEngine;

namespace RSGPlatformer.Game.World
{
    /// <summary>
    /// A class used for activatable movements, typically enemy movement
    /// </summary>
    public abstract class BasicActivatableMovement : BasicMovement, IActivatable
    {
        // if using serialization tools, then we can serialize a List<IActivatable> in the inspector for example.
        // but we're not using any right now, so we have to assign this field.
        [SerializeField]
        private ActivationZone activationZone;
        public bool Activated { get; set; } = false;

        protected override void Awake()
        {
            base.Awake();
            activationZone.AddActivatable(this);
        }

        public virtual void Activate()
        {
            ResetState();
            if (!gameObject.activeInHierarchy)
                gameObject.SetActive(true);
            Activated = true;
        }

        public virtual void Deactivate()
        {
            if (gameObject.activeInHierarchy)
                gameObject.SetActive(false);
            Activated = false;
        }
    }
}