using System.Collections;
using System.Collections.Generic;
using RSGPlatformer.Game.Management;
using UnityEngine;

namespace RSGPlatformer.Game.World
{
    public class ScorePickup : BasicTriggerEffect
    {
        [SerializeField]
        private int scoreGained;

        protected override void TriggerEffect(Collider2D other)
        {
            GameController.Instance.AddScore(this, scoreGained);
            gameObject.SetActive(false);
        }
    }
}