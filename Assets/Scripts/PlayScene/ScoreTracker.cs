using TMPro;
using UnityEngine;

namespace NeonImpact.PlayScene
{
    public class ScoreTracker : MonoBehaviour
    {
        public TMP_Text scoreText;
        private const int StartingScore = 0;
        private int _currentScore;
        
        void Start()
        {
            GameManager.Instance.ScoreIncremented += IncreaseScore;
            GameManager.Instance.GameStarted += ResetScore;
            _currentScore = StartingScore;
            DisplayScore();
        }

        private void IncreaseScore()
        {
            _currentScore++;
            GameManager.Instance.currentScore = _currentScore;
            DisplayScore();
        }

        private void DisplayScore()
        {
            scoreText.text = _currentScore.ToString();
          
        }

        public void ResetScore()
        {
            _currentScore = StartingScore;
            DisplayScore();
        }
    }
}