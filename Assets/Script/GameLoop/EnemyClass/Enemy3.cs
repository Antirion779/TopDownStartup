using System.Collections;
using System.Collections.Generic;
using Game.Script.GameLoop;
using UnityEngine;

namespace Game
{
    public class Enemy3 : Entity
    {
        private GameManager _gameManager; 
        private void Awake()
        {
            //insert enemy behaviour here. 
        }
        
        private void OnDestroy()
        {
            _gameManager.DeleteEnemyFromList(this);
            _gameManager.enemyList.Remove(gameObject);
        }
    }
}
