using System;

public class LivesChangedArgs : EventArgs
{
    public int NewLives {get;}
    public LivesChangedArgs(int newLives)
    {
        NewLives = newLives;
    }
}