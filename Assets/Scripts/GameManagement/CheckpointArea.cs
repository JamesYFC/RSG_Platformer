using System;
using System.Collections.Generic;
using UnityEngine;

namespace RSGPlatformer.Game.World
{
    [Serializable]
    public class CheckpointArea
    {
        [SerializeField]
        private List<ActivationZone> activationZones;
        [SerializeField]
        private Checkpoint _checkPoint;
        public Checkpoint Checkpoint => _checkPoint;
        public void ResetZones()
        {
            foreach (var activationZone in activationZones)
            {
                activationZone.ResetState();
            }
        }
    }
}