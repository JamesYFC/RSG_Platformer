using System;
using System.Collections.Generic;

public class Level
{
    private int currentCheckpoint;
    private List<Checkpoint> checkpoints;
    public EventHandler<CheckpointCompletedArgs> CheckpointCompleted;
    public void CheckpointComplete(int i)
    {

    }
    public void CheckpointReset(int i)
    {
        
    }
}

public class Checkpoint
{
    private List<IResettable> checkpointObjects;
    public Checkpoint(IList<IResettable> checkpointObjects)
    {
        this.checkpointObjects = (List<IResettable>)checkpointObjects;
    }
    public void Reset()
    {

    }
}

public class CheckpointCompletedArgs
{
    public int CompletedCheckpoint {get;}
    public CheckpointCompletedArgs(int completedCheckpoint)
    {
        CompletedCheckpoint = completedCheckpoint;
    }
}