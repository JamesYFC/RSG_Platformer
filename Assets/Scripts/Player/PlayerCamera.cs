using RSGPlatformer.Game.Management;
using UnityEngine;

namespace RSGPlatformer.Game.World
{
    /// <summary>
    /// The player camera script.
    /// This script moves the attached object to follow the player as they move to the right, but does not follow the player to the left.
    /// </summary>
    public class PlayerCamera : MonoBehaviour, IResettable
    {
        [SerializeField]
        private Transform trackedTransform;

        private void Start()
        {
            SetInitialPosition();
        }

        private void SetInitialPosition()
        {
            if (trackedTransform == null)
            {
                Debug.LogError("This script should track a Transform!");
                return;
            }

            transform.position = new Vector3(trackedTransform.position.x, trackedTransform.position.y, transform.position.z);
        }

        private void SetInitialPosition(Transform newTrackedTransform)
        {
            trackedTransform = newTrackedTransform;
            SetInitialPosition();
        }

        private void Update()
        {
            SetCalculatedPosition();
        }

        private void SetCalculatedPosition()
        {
            Vector2 positionDifference = trackedTransform.position - transform.position;

            // apply all differences except in the negative x axis.
            if (positionDifference.x < 0)
            {
                positionDifference.x = 0;
            }

            transform.position += new Vector3(positionDifference.x, positionDifference.y, 0);
        }

        public void ResetState()
        {
            SetInitialPosition();
        }
    }
}