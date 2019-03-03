using RSGPlatformer.Game.Management;
using UnityEngine;
using UnityEngine.UI;

namespace RSGPlatformer.Game.UI
{
    /// <summary>
    /// A class to handle UI show/hiding and updating UI elements.
    /// </summary> 
    public class UIManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject topBar;
        [SerializeField]
        private Text lives;
        [SerializeField]
        private Text score;
        [SerializeField]
        private HighScoresUI highScoresUI;

        private void Awake()
        {
            if (lives == null) Debug.LogError("lives should not be nulL!");
            if (score == null) Debug.LogError("score should not be null!");
        }

        private void OnEnable()
        {
            GameController.Instance.LivesChanged += LivesChangedUpdate;
            GameController.Instance.ScoreChanged += ScoreChangedUpdate;
            GameController.Instance.GameFinished += GameFinishedUpdate;
        }
        private void OnDisable()
        {
            GameController.Instance.LivesChanged -= LivesChangedUpdate;
            GameController.Instance.GameFinished -= GameFinishedUpdate;
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

        protected void GameFinishedUpdate(object sender, GameFinishedArgs e)
        {
            GameFinished(e.FinalScore);
        }


        public void UpdateLives(int newLives)
        {
            lives.text = newLives.ToString();
        }

        public void UpdateScore(int newScore)
        {
            score.text = newScore.ToString();
        }

        public void GameFinished(int finalScore)
        {
            topBar.SetActive(false);
            highScoresUI.ShowAndSetScores(GameController.Instance.HighScores, finalScore);
        }
    }
}