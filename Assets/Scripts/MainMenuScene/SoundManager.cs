using UnityEngine;

namespace NeonImpact.MainMenuScene
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager Instance;
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip buttonSounds;
    
        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }

        private void Start()
        {
            DontDestroyOnLoad(this);
            audioSource.volume = .7f;
            audioSource.Play();
        }

        public void PlayButtonSound()
        {
            audioSource.PlayOneShot(buttonSounds);
        }

    }
}
