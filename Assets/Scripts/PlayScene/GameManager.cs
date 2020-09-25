using System;
using UnityEngine;

namespace NeonImpact.PlayScene
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        public event Action GameStarted, GameLost, ScoreIncremented;
        [SerializeField] private bool _isPlaying = true;
        [HideInInspector] public int currentScore;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }

        private void Update()
        {
            if (_isPlaying == false)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f;
            }
        }

        public void StartGame()
        {
            if (_isPlaying == false)
            {
                _isPlaying = true;
            }

            GameStarted?.Invoke();
        }

        public void LoseGame()
        {
            if (_isPlaying == true)
            {
                _isPlaying = false;
            }

            GameLost?.Invoke();
        }

        public void IncrementScore()
        {
            ScoreIncremented?.Invoke();
        }
    }
}