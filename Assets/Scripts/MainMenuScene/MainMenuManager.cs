using System.Collections;
using NeonImpact.PlayScene;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NeonImpact.MainMenuScene
{
    public class MainMenuManager : MonoBehaviour
    {
        private void StartGame()
        {
            SoundManager.Instance.PlayButtonSound();
            SceneManager.LoadScene("SinglePlayer");
        }

        public void QuitGame()
        {
            SoundManager.Instance.PlayButtonSound();
            Application.Quit();
        }
    }
}