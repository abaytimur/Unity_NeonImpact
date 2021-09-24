using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace NeonImpact
{
    public class SinglePlayerSoundManager : MonoBehaviour
    {
        [SerializeField] public AudioSource audioSource;
        [SerializeField] private AudioClip collideSound;
        [SerializeField] private AudioClip playerHurtSound;
        [SerializeField] private AudioClip difficultySounds;
        [SerializeField] private AudioClip otherEnemyCollideSound;
        [SerializeField] private AudioClip fireballSound;

        private void Start()
        {
            audioSource.volume = .7f;
        }

        public void PlayCollideSound()
        {
            audioSource.volume = .7f;
            audioSource.pitch = Random.Range(0.85f, 1.15f);
            audioSource.PlayOneShot(collideSound);
        } 
        public void PlayDifficultySound()
        {
            audioSource.volume = 1f;
            audioSource.pitch = 1f;
            audioSource.PlayOneShot(difficultySounds);
        }

        public void PlayPlayerHurtSound()
        {
            audioSource.volume = 1f;
            audioSource.pitch = Random.Range(0.95f, 1.05f);
            audioSource.PlayOneShot(playerHurtSound);
        }

        public void PlayOtherEnemyCollildeSound()
        {            
            audioSource.volume = .7f;
            audioSource.pitch = Random.Range(0.95f, 1.05f);
            audioSource.PlayOneShot(otherEnemyCollideSound);
        }
        
        public void PlayFireballSound()
        {            
            audioSource.volume = .5f;
            audioSource.pitch = Random.Range(0.95f, 1.05f);
            audioSource.PlayOneShot(fireballSound);
        }
    }
}
