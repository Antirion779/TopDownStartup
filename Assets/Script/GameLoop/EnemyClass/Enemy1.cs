using System;
using System.Collections;
using System.Collections.Generic;
using Game.Script.GameLoop;
using UnityEditor;
using UnityEngine;

namespace Game
{
    public class Enemy1 : Entity
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
