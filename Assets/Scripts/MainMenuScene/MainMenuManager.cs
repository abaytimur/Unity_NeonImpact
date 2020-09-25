using NeonImpact.PlayScene;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NeonImpact.MainMenuScene
{
    public class MainMenuManager : MonoBehaviour
    {
        

        private void Start()
        {
            GameManager.Instance.GameStarted += StartGame;
            
        }

        private void StartGame()
        {
            GameManager.Instance.GameStarted -= StartGame;
            SceneManager.LoadScene("SampleScene");
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}