using System.Collections;
using System.Collections.Generic;
using RSGPlatformer.Game.Management;
using UnityEngine;

namespace RSGPlatformer.Game.World
{
    public class EnemyController : MonoBehaviour, IKillable
    {
        [SerializeField]
        private int killScore = 50;

        public virtual void Die(GameObject source)
        {
            GameController.Instance.AddScore(this, killScore);
        }
    }
}
