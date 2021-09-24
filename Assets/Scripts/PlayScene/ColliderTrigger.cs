using UnityEngine;

namespace NeonImpact.PlayScene
{
    public class ColliderTrigger : MonoBehaviour
    {
        private ScoreTracker _scoreTracker;
        public GameObject particleEffect;
        private SinglePlayerSoundManager _singlePlayerSoundManager;
        private void Awake()
        {
            _singlePlayerSoundManager = FindObjectOfType<SinglePlayerSoundManager>();
            _scoreTracker = FindObjectOfType<ScoreTracker>();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag($"Enemy"))
            {
                GameManager.Instance.IncrementScore();
                _singlePlayerSoundManager.PlayCollideSound();
                other.gameObject.tag = "CollidedEnemy";
                Instantiate(particleEffect, other.transform.position, other.transform.rotation);
            }
        }
    }
}