using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : SingletonMonoBehaviour<GameController>
{
    [SerializeField]
    private PlayerController player;
    [SerializeField]
    private int lives = 3;
    private int score;
    public EventHandler<LevelResetArgs> LevelReset;
    public void AddScore(int scoreToAdd) => score += scoreToAdd;
    public void PlayerDied()
    {
        Debug.Assert(lives > 0);

        lives--;

        if (lives > 0)
        {
            player.ResetState();
        }
        else
        {
            GameOver();
        }
    }


    private void GameOver()
    {
        Debug.Log("Game Over!");
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
