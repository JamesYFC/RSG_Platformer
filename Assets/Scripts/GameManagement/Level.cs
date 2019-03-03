using System;
using System.Collections.Generic;
using RSGPlatformer.Game.World;
using UnityEngine;

namespace RSGPlatformer.Game.Management
{
    [Serializable]
    public class Level
    {
        private int currentCheckpointIndex;
        private List<CheckpointArea> checkpoints;
        public Transform CurrentSpawnPoint => checkpoints[currentCheckpointIndex].Checkpoint.transform;
        public Level(IList<CheckpointArea> checkpoints)
        {
            currentCheckpointIndex = 0;
            this.checkpoints = (List<CheckpointArea>)checkpoints;
            for (int i = 0; i < checkpoints.Count; i++)
            {
                checkpoints[i].Checkpoint.Setup(i);
            }
        }

        public void CheckpointReached(int i)
        {
            currentCheckpointIndex = i;
        }

        public void CheckpointReset()
        {
            checkpoints[currentCheckpointIndex].ResetZones();
        }
    }
}