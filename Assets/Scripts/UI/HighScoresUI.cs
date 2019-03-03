using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RSGPlatformer.Game.UI
{
    public class HighScoresUI : MonoBehaviour
    {
        [SerializeField]
        List<Text> highScoreTexts;
        [SerializeField]
        Text finalScore;

        private void Awake()
        {
            gameObject.SetActive(false);
        }

        public void ShowAndSetScores(IList<int> highScores, int currentScore)
        {
            gameObject.SetActive(true);

            for (int i = 0; i < highScores.Count; i++)
            {
                this.highScoreTexts[i].text = highScores[i].ToString();
            }
            finalScore.text = currentScore.ToString();
        }
    }
}