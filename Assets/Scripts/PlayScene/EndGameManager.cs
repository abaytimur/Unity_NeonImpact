using System;
using NeonImpact.MainMenuScene;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NeonImpact.PlayScene
{
    public class EndGameManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text currentScore;
        [SerializeField] private TMP_Text highScoreText;
        public void RestartGame()
        {
            //burası yanlış olmuş main menüdeki buttonSound bu
            //SoundManager.Instance.PlayButtonSound();
            SoundManager.Instance.PlayButtonSound();

            GameManager.Instance.currentScore = 0;
            GameManager.Instance.StartGame();
            gameObject.SetActive(false);
        }

        public void GoToMainMenu()
        {
            SoundManager.Instance.PlayButtonSound();
            gameObject.SetActive(false);
            SceneManager.LoadScene("MainMenu");
        }

        private void OnEnable()
        {
            SetHighScoreText();
        }

        private void SetHighScoreText()
        {
            currentScore.text = $"Score: {GameManager.Instance.currentScore}";
            highScoreText.text = $"All Time High Score: {PlayerPrefs.GetInt("AllTimeHighScore")}";
        }
    }
}