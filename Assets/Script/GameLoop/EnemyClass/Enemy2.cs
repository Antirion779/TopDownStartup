using System.Collections;
using System.Collections.Generic;
using Game.Script.GameLoop;
using UnityEngine;

namespace Game
{
    public class Enemy2 : Entity
    {
        private GameManager _gameManager;
        private void Awake()
        {
            //insert enemy behaviour here. 
        }
        
        private void OnDestroy()
        {
            _gameManager.enemyList.Remove(gameObject);
        }
    }
}
