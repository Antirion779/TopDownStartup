using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public abstract class EnemyFactory : MonoBehaviour
    {
        public abstract Entity EntitySpawn();

        public Vector3 EnemySpawnPosition()
        {
            return transform.position; 
        }
    }
}
