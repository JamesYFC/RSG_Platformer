using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text lives;
    [SerializeField]
    private Text score;

    private void Awake()
    {
        if (lives == null) Debug.LogError("lives should not be nulL!");
        if (score == null) Debug.LogError("score should not be null!");
        
        GameController.Instance.LivesChanged += LivesChanged;
        GameController.Instance.ScoreChanged += ScoreChanged;
    }

    protected void LivesChanged(object sender, LivesChangedArgs e)
    {
        UpdateLives(e.NewLives);
    }

    protected void ScoreChanged(object sender, ScoreChangedArgs e)
    {
        UpdateScore(e.NewScore);
    }


    public void UpdateLives(int newLives)
    {
        lives.text = newLives.ToString();
    }

    public void UpdateScore(int newScore)
    {
        score.text = newScore.ToString();
    }
}
