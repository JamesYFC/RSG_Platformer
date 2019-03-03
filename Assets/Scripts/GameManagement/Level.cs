using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Level
{
    private int currentCheckpointIndex;
    private List<CheckpointArea> checkpoints;
    public Transform CurrentSpawnPoint => checkpoints[currentCheckpointIndex].SpawnPoint;
    public Level(IList<CheckpointArea> checkpoints)
    {
        currentCheckpointIndex = 0;
        this.checkpoints = (List<CheckpointArea>)checkpoints;
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
