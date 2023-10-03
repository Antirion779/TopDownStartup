using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [Required("nop")]public Health health;

    private void Awake()
    {
        health.OnDie += () => Destroy(gameObject);
    }
}
