using DG.Tweening;
using UnityEngine;

namespace NeonImpact.PlayScene
{
    public class Player : MonoBehaviour
    {
        public GameObject endGamePanel;
        [SerializeField] private float _speed;
        private SinglePlayerSoundManager _singlePlayerSoundManager;
        private ScoreTracker _scoreTracker;
        private BonusPointController _bonusPointController;
        
        [SerializeField] private GameObject otherEnemyParticleEffect;
        [SerializeField] private Material yellowEnemy;
        
        private void Awake()
        {
            _bonusPointController = FindObjectOfType<BonusPointController>();
            _singlePlayerSoundManager = FindObjectOfType<SinglePlayerSoundManager>();
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
                transform1.DOLocalRotate(new Vector3(0f, -5f, 0f), .3f);
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                transform.DOLocalRotate(new Vector3(0f, 0f, 0f), .5f);
            }
        }

        private void MoveLeft()
        {
            if (Input.GetKey(KeyCode.A) && transform.position.x >= -4.30f)
            {
                var transform1 = transform;
                transform1.position += Vector3.left * (_speed * Time.deltaTime);
                transform1.DOLocalRotate(new Vector3(0F, 5f, 0f), .3f);
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                transform.DOLocalRotate(new Vector3(0f, 0f, 0f), .5f);
            }
        }

        #endregion

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag($"Enemy"))
            {
                _singlePlayerSoundManager.PlayPlayerHurtSound();
                GameManager.Instance.LoseGame();
            }

            if (other.gameObject.CompareTag("CollidedEnemy"))
            {
                // Give bonus points
                // Play some cool animations
                other.gameObject.GetComponent<Renderer>().material = yellowEnemy;
                _bonusPointController.GiveBonusPointsForEnemy2();
                Instantiate(otherEnemyParticleEffect, other.gameObject.transform.position, other.gameObject.transform.rotation,other.gameObject.transform);
                PlayerCollidesWithCollidedEnemy();
            }
        }
        
        private void PlayerCollidesWithCollidedEnemy()
        {
            // Şu an 2 puan veriyor bu kodun nasıl işleyeceğine karar ver
            
            _singlePlayerSoundManager.PlayOtherEnemyCollildeSound();
            GameManager.Instance.IncrementScore();
            GameManager.Instance.IncrementScore();
        }
    }
}