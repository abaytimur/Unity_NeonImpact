using System;
using System.Collections;
using UnityEngine;

namespace NeonImpact.PlayScene
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        private EnemySpawner _enemySpawner;
        public event Action GameStarted, GameLost, ScoreIncremented;
        [SerializeField] private bool isPlaying = true;
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

        private void Start()
        {
            StartCoroutine(StartSinglePlayerGame());
        }

        private IEnumerator StartSinglePlayerGame()
        {
            yield return new WaitForSeconds(.1f);
            StartGame();
        }

        private void Update()
        {
            Time.timeScale = isPlaying == false ? 0f : 1f;
        }

        public void StartGame()
        {
            if (isPlaying == false)
            {
                isPlaying = true;
            }

            GameStarted?.Invoke();
        }

        public void LoseGame()
        {
            if (isPlaying)
            {
                isPlaying = false;
            }

            GameLost?.Invoke();
        }

        public void IncrementScore()
        {
            ScoreIncremented?.Invoke();
        }
    }
}