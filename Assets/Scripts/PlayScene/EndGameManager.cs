using UnityEngine;
using UnityEngine.SceneManagement;

namespace NeonImpact.PlayScene
{
    public class EndGameManager : MonoBehaviour
    {
        public void RestartGame()
        {
            gameObject.SetActive(false);
        }

        public void GoToMainMenu()
        {
            gameObject.SetActive(false);
            SceneManager.LoadScene("MainMenu");
        }
    }
}