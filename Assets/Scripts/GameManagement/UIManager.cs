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
    }

    private void OnEnable()
    {
        GameController.Instance.LivesChanged += LivesChangedUpdate;
        GameController.Instance.ScoreChanged += ScoreChangedUpdate;
    }
    private void OnDisable()
    {
        GameController.Instance.LivesChanged -= LivesChangedUpdate;
        GameController.Instance.ScoreChanged -= ScoreChangedUpdate;
    }

    protected void LivesChangedUpdate(object sender, LivesChangedArgs e)
    {
        UpdateLives(e.NewLives);
    }

    protected void ScoreChangedUpdate(object sender, ScoreChangedArgs e)
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
