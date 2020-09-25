using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace NeonImpact.PlayScene
{
    public class EnemySpawner : MonoBehaviour
    {
        public GameObject enemyPrefab;
        private Coroutine _spawnRoutine;

        private int _timer;
        [HideInInspector] public int maxTimer;
        [HideInInspector] public int enemyCounter = 0;

        void Start()
        {
            GameManager.Instance.GameStarted += StartSpawning;
            GameManager.Instance.GameLost += StopSpawning;

            _timer = maxTimer;
        }

        private void StopSpawning()
        {
            GameObject[] destroyableEnemyPrefabs = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (var enemy in destroyableEnemyPrefabs)
            {
                Destroy(enemy);
            }

            if (_spawnRoutine != null)
            {
                StopCoroutine(_spawnRoutine);
            }
        }

        private void StartSpawning()
        {
            _spawnRoutine = StartCoroutine(SpawnEnemy());
        }

        void FixedUpdate()
        {
            if (_timer <= 0)
            {
                StartCoroutine(SpawnEnemy());
                _timer = maxTimer;
            }

            _timer--;
        }

        IEnumerator SpawnEnemy()
        {
            yield return new WaitForSeconds(1f);
            float randomX = Random.Range(-3.5f, 3.5f);
            enemyCounter++;
            GameObject enemy = Instantiate(enemyPrefab, new Vector3(randomX, 7, -8.43f), Random.rotation);
            Destroy(enemy, 4f);
        }
    }
}