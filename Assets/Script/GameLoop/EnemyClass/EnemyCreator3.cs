using System;
using System.Collections;
using System.Collections.Generic;
using Game.Script.GameLoop;
using UnityEngine;

namespace Game
{
    public class EnemyCreator3 : EnemyFactory
    {
        public GameObject enemyPrefab;

        public override Entity EntitySpawn()
        {
            GameObject enemyInstantiated = Instantiate(enemyPrefab, EnemySpawnPosition(), Quaternion.identity);
            return enemyInstantiated.GetComponent<Entity>();
        }

    }
}
