using System;
using UnityEngine;

namespace Game.Script.GameLoop
{
    public class EntityInteraction : MonoBehaviour
    {
        public bool canTeleport = false;
        private GameManager _gameManager; 
        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.name == "Teleport")
            {
                Debug.Log("COLLIDED");
                canTeleport = true; 
            }
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if(other.gameObject.name == "Teleport")
            {
                canTeleport = false; 
            }
        }


        private void Update()
        {
            if (Input.GetKey(KeyCode.Space) && canTeleport == true)
            {
                _gameManager.NextLevel();
            }
        }
    }
}
