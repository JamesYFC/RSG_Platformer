using System;

namespace RSGPlatformer.Game.Management
{
    public class GameFinishedArgs : EventArgs
    {
        public int FinalScore { get; }
        public GameFinishedArgs(int finalScore)
        {
            FinalScore = finalScore;
        }
    }
}