using RSGPlatformer.Game.Management;
using UnityEngine;

namespace RSGPlatformer.Game.World
{
    public class PlayerController : MonoBehaviour, IKillable, IResettable
    {
        [SerializeField]
        private PlayerMovement playerMovement;

        public void SetStartPosition(Vector2 position) => playerMovement.SetStartPosition(position);
        public void Die(GameObject source)
        {
            Debug.Log("I am dead!");
            GameController.Instance.PlayerDied(source);
        }

        public void ResetState()
        {
            playerMovement.ResetState();
        }
    }
}