using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : SingletonMonoBehaviour<GameController>
{
    [SerializeField]
    private PlayerController player;

    [SerializeField]
    private int startingLives = 3;

    private GameState gameState;
    private int CurrentLives => gameState.Lives;

    public void Awake()
    {
        gameState = new GameState(startingLives);
    }

    public void AddScore(int scoreToAdd) => gameState.AddScore(scoreToAdd);

    public void PlayerDied()
    {
        Debug.Assert(CurrentLives > 0);

        gameState.LoseLife();

        if (CurrentLives > 0)
        {
            // TODO: checkpoint restarts
            player.ResetState();
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
