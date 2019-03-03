using System.Collections.Generic;
using RSGPlatformer.Game.Management;
using UnityEngine;

namespace RSGPlatformer.Game.World
{
    public class ActivationZone : BasicTriggerEffect, IResettable
    {
        private List<IActivatable> objectsToActivate = new List<IActivatable>();

        private void Awake()
        {
            if (objectsToActivate == null)
            {
                Debug.LogError("no objects to activate!");
            }
        }

        private void Start()
        {
            DeactivateAll();
        }

        protected override void TriggerEffect(Collider2D other)
        {
            ActivateAll();
            gameObject.SetActive(false);
        }

        public void AddActivatable(IActivatable activatable)
        {
            objectsToActivate.Add(activatable);
        }

        private void ActivateAll()
        {
            foreach (IActivatable activatable in objectsToActivate)
            {
                activatable.Activate();
            }
        }

        public void ResetState()
        {
            DeactivateAll();
            gameObject.SetActive(true);
        }

        private void DeactivateAll()
        {
            foreach (IActivatable activatable in objectsToActivate)
            {
                activatable.Deactivate();
            }
        }
    }
}