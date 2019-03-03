namespace RSGPlatformer.Game.Management
{
    /// <summary>
    /// This class keeps track of various core variables for the game state.
    /// </summary>
    public class GameState
    {
        public int StartingLives { get; }
        public int Lives { get; private set; }
        public int Score { get; private set; }

        public GameState(int startingLives)
        {
            StartingLives = startingLives;
            Setup();
        }

        public void Setup()
        {
            Lives = StartingLives;
            Score = 0;
        }

        public void AddScore(int scoreToAdd) => Score += scoreToAdd;
        public void LoseLife() => Lives--;
    }
}