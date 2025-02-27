using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class EntityAttack : MonoBehaviour
{
    [SerializeField] AttackZone _attackZone;

    public event UnityAction OnAttack;
    private int _bonusDamage = 0;

    public bool _canAttack = true;

    public IEnumerator LaunchAttack()
    {
        OnAttack?.Invoke();
        foreach (var el in _attackZone.InZone)
        {
            //el.Damage(10);
            
            if (_canAttack)
            {
                el.Damage(10 + _bonusDamage);
            }
        }

        if (_attackZone.InZone.Count() > 0)
        {
            _canAttack = false;
            yield return new WaitForSeconds(2f);
            _canAttack = true;
        }
    }

    public void AddBonusDamage(int bonusDamage)
    {
        bonusDamage += bonusDamage;
    }
}