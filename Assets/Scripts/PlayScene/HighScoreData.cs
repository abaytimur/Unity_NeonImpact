using UnityEngine;

namespace NeonImpact.PlayScene
{
    [CreateAssetMenu(fileName = "New HighScore Data", menuName = "Score")]
    public class HighScoreData : ScriptableObject
    {
        public int currentHighScore;
        public int allTimeHighScore;
        public int currentScore;
    
    }
}
