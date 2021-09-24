using System;
using UnityEngine;

namespace NeonImpact.PlayScene
{
    [CreateAssetMenu(fileName = "New HighScore Data", menuName = "Score")]
    public class HighScoreData : ScriptableObject
    {
        public int currentHighScore;
        public int allTimeHighScore;
        public int currentScore;

        public void SetPlayerPrefsForHighScores()
        {
            PlayerPrefs.SetInt("CurrentHighScore",currentHighScore);
            PlayerPrefs.SetInt("AllTimeHighScore",allTimeHighScore);
        }

        public int GetPlayerPrefsAllTimeHighScore()
        {
            return PlayerPrefs.GetInt("AllTimeHighScore");
        }
    }
}
