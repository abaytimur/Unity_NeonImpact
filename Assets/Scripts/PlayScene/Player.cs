using UnityEngine;

namespace NeonImpact.PlayScene
{
    public class Player : MonoBehaviour
    {
        public GameObject endGamePanel;
        [SerializeField] private float _speed;

        private ScoreTracker _scoreTracker;

        private void Awake()
        {
            _scoreTracker = FindObjectOfType<ScoreTracker>();
        }

        void Start()
        {
            GameManager.Instance.GameLost += EndGame;
            _speed = 10;
        }

        private void EndGame()
        {
            endGamePanel.SetActive(true);
            _scoreTracker.ResetScore();
            gameObject.transform.position = new Vector3(0, 0.873f, -8.432f);
        }

        void Update()
        {
            MoveLeft();
            MoveRight();
        }

        #region Movement

        private void MoveRight()
        {
            if (Input.GetKey(KeyCode.D) && transform.position.x <= 4.30f)
            {
                var transform1 = transform;
                transform1.position -= Vector3.left * (_speed * Time.deltaTime);
            }
        }

        private void MoveLeft()
        {
            if (Input.GetKey(KeyCode.A) && transform.position.x >= -4.30f)
            {
                var transform1 = transform;
                transform1.position += Vector3.left * (_speed * Time.deltaTime);
            }
        }

        #endregion

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag($"Enemy"))
            {
                // EndGame();
                GameManager.Instance.LoseGame();
            }
        }
    }
}