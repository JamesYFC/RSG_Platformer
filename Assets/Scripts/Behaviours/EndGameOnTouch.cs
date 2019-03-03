using RSGPlatformer.Game.Management;
using UnityEngine;

namespace RSGPlatformer.Game.World.World
{
    public class EndGameOnTouch : BasicTriggerEffect
    {
        protected override void TriggerEffect(Collider2D other)
        {
            GameController.Instance.GameOver();
        }
    }
}
