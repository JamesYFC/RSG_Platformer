using System;

public class ScoreChangedArgs : EventArgs
{
    public int NewScore {get;}
    public ScoreChangedArgs(int newScore)
    {
        NewScore = newScore;
    }
}