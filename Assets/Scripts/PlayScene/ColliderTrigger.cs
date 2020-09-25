using UnityEngine;

namespace NeonImpact.PlayScene
{
    public class ColliderTrigger : MonoBehaviour
    {
        private ScoreTracker _scoreTracker;
        public GameObject particleEffect;

        private void Awake()
        {
            _scoreTracker = FindObjectOfType<ScoreTracker>();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag($"Enemy"))
            {
                GameManager.Instance.IncrementScore(); 
            
                // Display particle effects
                Instantiate(particleEffect, other.transform.position, other.transform.rotation);
            }
        }
    }
}