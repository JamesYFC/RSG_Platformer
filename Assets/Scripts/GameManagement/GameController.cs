using System;
using System.Collections;
using System.Collections.Generic;
using RSGPlatformer.Game.World;
using UnityEngine;
using UnityEngine.Events;

namespace RSGPlatformer.Game.Management
{
    public class GameController : SingletonMonoBehaviour<GameController>
    {
        [SerializeField]
        private PlayerController player;
        [SerializeField]
        private PlayerCamera playerCamera;

        [SerializeField]
        private int startingLives = 3;

        private GameState gameState;
        public int CurrentLives => gameState.Lives;
        public int CurrentScore => gameState.Score;

        [SerializeField]
        private List<CheckpointArea> checkpoints;
        private Level currentLevel;

        private HighScoreManager highScoreManager;
        [SerializeField]
        private string highScoreFileLocation;
        [SerializeField]
        private int numHighScores = 5;
        public List<int> HighScores => highScoreManager.GetHighScores();

        public event EventHandler<ScoreChangedArgs> ScoreChanged;
        public event EventHandler<LivesChangedArgs> LivesChanged;
        public event EventHandler<GameFinishedArgs> GameFinished;

        public void Awake()
        {
            gameState = new GameState(startingLives);
            currentLevel = new Level(checkpoints);
            highScoreManager = new HighScoreManager(highScoreFileLocation, numHighScores);
            highScoreManager.LoadHighScores();
        }

        protected virtual void OnScoreChanged(object sender, ScoreChangedArgs e) => ScoreChanged?.Invoke(sender, e);
        protected virtual void OnLivesChanged(object sender, LivesChangedArgs e) => LivesChanged?.Invoke(sender, e);
        protected virtual void OnGameFinished(object sender, GameFinishedArgs e) => GameFinished?.Invoke(sender, e);

        public void CheckpointReached(int checkpointIndex)
        {
            currentLevel.CheckpointReached(checkpointIndex);
            player.SetStartPosition(currentLevel.CurrentSpawnPoint.position);
        }

        public void AddScore(object source, int scoreToAdd)
        {
            gameState.AddScore(scoreToAdd);
            OnScoreChanged(source, new ScoreChangedArgs(CurrentScore));
        }

        public void PlayerDied(object source)
        {
            Debug.Assert(CurrentLives > 0);

            gameState.LoseLife();
            OnLivesChanged(source, new LivesChangedArgs(CurrentLives));

            if (CurrentLives > 0)
            {
                currentLevel.CheckpointReset();
                player.ResetState();
                playerCamera.ResetState();
            }
            else
            {
                if (CurrentLives < 0)
                    Debug.LogWarning("Lives is below zero!");

                GameOver();
            }
        }

        public void GameOver()
        {
            Debug.Log("Game Over!");

            player.gameObject.SetActive(false);

            int finalScore = CurrentScore;
            if (highScoreManager.EnterHighScore(finalScore))
            {
                highScoreManager.WriteHighScores();
            }

            OnGameFinished(this, new GameFinishedArgs(finalScore));
        }

        public void Restart()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }
}