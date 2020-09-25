using UnityEngine;

namespace NeonImpact.PlayScene
{
    public class Difficulty : MonoBehaviour
    {
        private EnemySpawner _enemySpawner;

        private void Awake()
        {
            // Birden fazla enemy spawner ekleyeceksen findobjectSoftypes kullan
            _enemySpawner = FindObjectOfType<EnemySpawner>();
        }

        private void Update()
        {
            if (_enemySpawner.enemyCounter >= 5 && _enemySpawner.enemyCounter < 10)
            {
                _enemySpawner.maxTimer = 100;
            }

            if (_enemySpawner.enemyCounter >= 10 && _enemySpawner.enemyCounter < 15)
            {
                _enemySpawner.maxTimer = 75;
            }

            if (_enemySpawner.enemyCounter >= 15)
            {
                _enemySpawner.maxTimer = 30;
            }
        }
    }
}