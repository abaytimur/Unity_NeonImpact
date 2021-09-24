using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NeonImpact
{
    public class BonusPointController : MonoBehaviour
    {
        [SerializeField] private GameObject enemy2;
        public void GiveBonusPointsForEnemy2()
        {
            Instantiate(enemy2, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y+1), Quaternion.identity, gameObject.transform);
        }
    }
}
