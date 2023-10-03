using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using Game.Script.GameLoop;
using UnityEngine;

public class AttackZone : MonoBehaviour
{
    HashSet<IHealth> _inZone;

    public IEnumerable<IHealth> InZone => _inZone;
    private AttackZone _attackZone;
    [SerializeField] private int baseDamages; 
    private void Awake()
    {
        _inZone = new();  
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IHealth h = collision.GetComponent<IHealth>(); 
        if(h != null)
        {
            _inZone.Add(h);
            Debug.Log("AJOUT " + collision.gameObject.name);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IHealth h = collision.GetComponent<IHealth>(); 
        if(h != null)
        {
            _inZone.Remove(h);
        }
    }


}
