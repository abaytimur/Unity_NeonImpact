using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace NeonImpact.PlayScene
{
    public class EnemySpawner : MonoBehaviour
    {
        public GameObject enemyPrefab;
        private Coroutine _spawnRoutine;

        public int enemyCounter = 0;
        public float spawnTimeInSeconds = 3f;

        private Difficulty _difficulty;
        private SinglePlayerSoundManager _singlePlayerSoundManager;
        [SerializeField] private GameObject _enemySpawnerSpecial;
        [SerializeField] private GameObject difficultyParticle, difficulty2, difficulty3, difficulty4, difficulty5;

        private void Awake()
        {
            _singlePlayerSoundManager = FindObjectOfType<SinglePlayerSoundManager>();
            _difficulty = FindObjectOfType<Difficulty>();
        }

        void Start()
        {
            GameManager.Instance.GameStarted += StartSpawning;
            GameManager.Instance.GameLost += StopSpawning;
        }

        public void StopSpawning()
        {
            _enemySpawnerSpecial.gameObject.SetActive(false);

            enemyCounter = 0;
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

        public void StartSpawning()
        {
            _spawnRoutine = StartCoroutine(SpawnEnemy());
        }

        private GameObject ScaleRandomizer()
        {
            var scaledPrefab = enemyPrefab;
            float randomScaleNumber = Random.Range(.6f, 1.4f);
            scaledPrefab.transform.localScale = new Vector3(randomScaleNumber,randomScaleNumber,randomScaleNumber);
            return scaledPrefab;
        }
        IEnumerator SpawnEnemy()
        {
            while (true)
            {
                yield return new WaitForSeconds(spawnTimeInSeconds);
                float randomX = Random.Range(-3.5f, 3.5f);
                enemyCounter++;
                _difficulty.SetDifficulty();
                CheckForDifficultyPartical();
                GameObject enemy = Instantiate(ScaleRandomizer(), new Vector3(randomX, 7, -8.43f), Random.rotation);
                Destroy(enemy, 4f);
            }
        }

        private void CheckForDifficultyPartical()
        {
            if (enemyCounter == 5)
            {
                _singlePlayerSoundManager.PlayDifficultySound();
                Instantiate(difficultyParticle, difficulty2.transform.position, difficulty2.transform.rotation);
            }
            else if (enemyCounter == 10)
            {
                _singlePlayerSoundManager.PlayDifficultySound();
                Instantiate(difficultyParticle, difficulty3.transform.position, difficulty3.transform.rotation);
            }
            else if (enemyCounter == 15)
            {
                _singlePlayerSoundManager.PlayDifficultySound();
                Instantiate(difficultyParticle, difficulty4.transform.position, difficulty4.transform.rotation);
            }
            else if (enemyCounter == 25)
            {
                _singlePlayerSoundManager.PlayDifficultySound();
                Instantiate(difficultyParticle, difficulty5.transform.position, difficulty5.transform.rotation);
            }
        }
    }
}