using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameController : SingletonMonoBehaviour<GameController>
{
    [SerializeField]
    private PlayerController player;
    [SerializeField]
    private PlayerCamera playerCamera;

    [SerializeField]
    private int startingLives = 3;

    private GameState gameState;
    private int CurrentLives => gameState.Lives;
    private int CurrentScore => gameState.Score;

    [SerializeField]
    private List<CheckpointArea> checkpoints;
    private Level currentLevel;

    public event EventHandler<ScoreChangedArgs> ScoreChanged;
    public event EventHandler<LivesChangedArgs> LivesChanged;

    public void Awake()
    {
        gameState = new GameState(startingLives);
        currentLevel = new Level(checkpoints);
    }

    protected virtual void OnScoreChanged(object sender, ScoreChangedArgs e) => ScoreChanged?.Invoke(sender, e);
    protected virtual void OnLivesChanged(object sender, LivesChangedArgs e) => LivesChanged?.Invoke(sender, e);

    public void CheckpointReached(int i) 
    {
        currentLevel.CheckpointReached(i);
        player.SetStartPosition(currentLevel.CurrentSpawnPoint.position);
    }

    public void AddScore(object source, int scoreToAdd)
    {
        gameState.AddScore(scoreToAdd);
        ScoreChanged?.Invoke(source, new ScoreChangedArgs(CurrentScore));
    }

    public void PlayerDied(object source)
    {
        Debug.Assert(CurrentLives > 0);

        gameState.LoseLife();
        LivesChanged?.Invoke(source, new LivesChangedArgs(CurrentLives));

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

    private void GameOver()
    {
        Debug.Log("Game Over!");
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
