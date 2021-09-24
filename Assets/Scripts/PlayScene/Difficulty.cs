using System;
using UnityEngine;
using UnityEngine.UI;

namespace NeonImpact.PlayScene
{
    public class Difficulty : MonoBehaviour
    {
        private EnemySpawner _enemySpawner;
        [SerializeField] private GameObject difficulty2, difficulty3, difficulty4, difficulty5;
        [SerializeField] private EnemySpawnerSpecial _enemySpawnerSpecial;
        private void Awake()
        {
            // Birden fazla enemy spawner ekleyeceksen findobjectSoftypes kullan
            _enemySpawner = FindObjectOfType<EnemySpawner>();
        }
        
        public void SetDifficulty()
        {
            if (_enemySpawner.enemyCounter < 5)
            {
                _enemySpawner.spawnTimeInSeconds = 3f;

                difficulty2.SetActive(false);
                difficulty3.SetActive(false);
                difficulty4.SetActive(false);
                difficulty5.SetActive(false);

                _enemySpawnerSpecial.gameObject.SetActive(false);
            }

            if (_enemySpawner.enemyCounter >= 5 && _enemySpawner.enemyCounter < 10)
            {
                _enemySpawner.spawnTimeInSeconds = 2f;
                difficulty2.SetActive(true);
                difficulty3.SetActive(false);
                difficulty4.SetActive(false);    
                difficulty5.SetActive(false);

                _enemySpawnerSpecial.gameObject.SetActive(false);

            }

            if (_enemySpawner.enemyCounter >= 10 && _enemySpawner.enemyCounter < 15)
            {
                _enemySpawner.spawnTimeInSeconds = 1f;
                difficulty2.SetActive(true);
                difficulty3.SetActive(true);
                difficulty4.SetActive(false);
                difficulty5.SetActive(false);

                _enemySpawnerSpecial.gameObject.SetActive(false);
            }

            if (_enemySpawner.enemyCounter >= 15 && _enemySpawner.enemyCounter < 25)
            {
                _enemySpawner.spawnTimeInSeconds = .75f;
                difficulty2.SetActive(true);
                difficulty3.SetActive(true);
                difficulty4.SetActive(true);
                difficulty5.SetActive(false);
                _enemySpawnerSpecial.gameObject.SetActive(false);


            }

            if (_enemySpawner.enemyCounter >= 25)
            {
                _enemySpawnerSpecial.gameObject.SetActive(true);
                difficulty2.SetActive(true);
                difficulty3.SetActive(true);
                difficulty4.SetActive(true);
                difficulty5.SetActive(true);
            }
        }
    }
}