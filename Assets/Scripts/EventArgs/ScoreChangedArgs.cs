using System;

namespace RSGPlatformer.Game.Management
{
    public class ScoreChangedArgs : EventArgs
    {
        public int NewScore { get; }
        public ScoreChangedArgs(int newScore)
        {
            NewScore = newScore;
        }
    }
}