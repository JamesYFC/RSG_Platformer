using System;

namespace RSGPlatformer.Game.Management
{
    public class LivesChangedArgs : EventArgs
    {
        public int NewLives { get; }
        public LivesChangedArgs(int newLives)
        {
            NewLives = newLives;
        }
    }
}