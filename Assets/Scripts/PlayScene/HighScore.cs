using UnityEngine;

namespace NeonImpact.PlayScene
{
    public class HighScore : MonoBehaviour
    {
        public HighScoreData highScoreData;

        private void Awake()
        {
            highScoreData.currentHighScore = 0;
            highScoreData.allTimeHighScore = highScoreData.GetPlayerPrefsAllTimeHighScore();
        }

        private void Start()
        {
            GameManager.Instance.ScoreIncremented += SaveHighScores;
            highScoreData.currentScore = 0;
        }

        public void SaveHighScores()
        {
            highScoreData.currentScore = GameManager.Instance.currentScore;

            if (highScoreData.currentScore > highScoreData.allTimeHighScore)
            {
                highScoreData.allTimeHighScore = highScoreData.currentScore;
            }

            if (highScoreData.currentScore > highScoreData.currentHighScore)
            {
                highScoreData.currentHighScore = highScoreData.currentScore;
            }

            highScoreData.SetPlayerPrefsForHighScores();
        }
    }
}