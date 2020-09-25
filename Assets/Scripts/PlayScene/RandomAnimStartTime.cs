using UnityEngine;
using Random = UnityEngine.Random;

namespace NeonImpact.PlayScene
{
    public class RandomAnimStartTime : MonoBehaviour
    {

        private Animator _animator;
    
        void Start()
        {
            _animator = GetComponent<Animator>();
            Invoke(nameof(PlayAnimationAtRandomTime),Random.Range(0f,1.5f));
        }

        void PlayAnimationAtRandomTime()
        {
            _animator.Play("s6", 0,0);
        }
    }
}
