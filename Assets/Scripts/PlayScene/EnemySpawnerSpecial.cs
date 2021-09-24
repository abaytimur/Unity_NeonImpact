using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

namespace NeonImpact.PlayScene
{
    public class EnemySpawnerSpecial : MonoBehaviour
    {

        [SerializeField] private GameObject specialEnemyPrefab;
        [SerializeField] private Transform spawnEndLocation;

        private SinglePlayerSoundManager _singlePlayerSoundManager;

        private void Awake()
        {
            _singlePlayerSoundManager = FindObjectOfType<SinglePlayerSoundManager>();
        }

        private void OnEnable()
        {
            StartCoroutine(SpawnSpecialEnemy());

        }
        
        private GameObject ScaleRandomizer()
        {
            var scaledPrefab = specialEnemyPrefab;
            float randomScaleNumber = Random.Range(.8f, 1.2f);
            scaledPrefab.transform.localScale = new Vector3(randomScaleNumber,randomScaleNumber,randomScaleNumber);
            return scaledPrefab;
        }
        
        public IEnumerator SpawnSpecialEnemy()
        {
            while (true)
            {
                yield return new WaitForSeconds(2f);
                
                float randomX = Random.Range(-3.5f, 3.5f);

                var position1 = transform.position;
                GameObject enemy = Instantiate(ScaleRandomizer(), new Vector3(randomX,position1.y,position1.z), Random.rotation);

                var position = spawnEndLocation.position;
                enemy.transform.DOMove(new Vector3(randomX,position.y, position.z), 2f);
                
                _singlePlayerSoundManager.PlayFireballSound();
                Destroy(enemy, 4f);

            }
        }

    }
}
