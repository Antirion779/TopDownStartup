using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Script.GameLoop
{
    public class GameManager : MonoBehaviour
    {
        private int _enemyCount = -1;

        public List<GameObject> enemyList = new List<GameObject>();
        public List<EnemyFactory> factoryList = new List<EnemyFactory>();

        public Entity player; 

        public int levelCleared = 0;

        private void Awake()
        {
            player.objectDestroyed += (_) => Application.Quit(); 
        }

        private void Update()
        {
            _enemyCount = enemyList.Count;
            if (_enemyCount == 0)
            {
                GoNextLevel();
            }
        }

        private void SpawnEnemy()
        {
            foreach (EnemyFactory factory in factoryList)
            {
                var entity = factory.EntitySpawn();
                enemyList.Add(entity.gameObject);
                entity.objectDestroyed += DeleteEnemyFromList; 
            }
        }

        public void DeleteEnemyFromList(GameObject enemy)
        {
            enemyList.Remove(enemy);
        }

        public void NextLevel()
        {
            levelCleared++;
            SpawnEnemy();
            EnemyStrength();

            //Upgrade();
        }

        /*private void Upgrade()
        {
            int upgrade = 0;
            switch (upgrade)
            {
                case 1:
                    //player damages ++
                    break; 
                case 2:
                    //player Health ++
                    break; 
                case 3: 
                    //player speed ++
                    break; 
            }
        }*/

        private void EnemyStrength()
        {
            foreach (var enemy in enemyList)
            {
                enemy.GetComponent<Health>().AddBonus(levelCleared * 10);
                enemy.GetComponentInChildren<EntityAttack>().AddBonusDamage(levelCleared);
                enemy.GetComponentInChildren<EntityMovement>().AddBonusSpeed(levelCleared * 100);
            }
        }

        private void GoNextLevel()
        {
            NextLevel();
        }
    }
}