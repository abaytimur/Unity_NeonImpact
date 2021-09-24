using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace NeonImpact
{
    public class BonusScore : MonoBehaviour
    {
        private void OnEnable()
        {
            PlayBonusScoreAnimation();
        }

        public void PlayBonusScoreAnimation()
        {
            float randomX = Random.Range(-25, 25);
            gameObject.transform.DOLocalMove(new Vector3(randomX, 400, 0f), .7f);
            gameObject.transform.DOScale(1.3f, 1f);
            gameObject.GetComponent<CanvasGroup>().DOFade(1f, .7f).OnComplete(() =>
            {
                gameObject.GetComponent<CanvasGroup>().DOFade(0, .3f);
                Destroy(gameObject,1f);
            });
        }   
    }
}
