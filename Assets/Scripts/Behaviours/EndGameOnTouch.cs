using RSGPlatformer.Game.Management;
using UnityEngine;

namespace RSGPlatformer.Game.World.World
{
    public class EndGameOnTouch : ScorePickup
    {
        protected override void TriggerEffect(Collider2D other)
        {
            base.TriggerEffect(other);
            GameController.Instance.GameOver();
        }
    }
}
