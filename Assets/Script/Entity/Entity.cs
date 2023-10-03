using System;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using Game.Script.GameLoop;
using UnityEngine;
using UnityEngine.Events;

public class Entity : MonoBehaviour
{
    [Required("nop")]public Health health;
    public Action<GameObject> objectDestroyed;

    protected void Awake()
    {
        health.OnDie += () => Destroy(gameObject);
    }

    protected void OnDestroy()
    {
        objectDestroyed?.Invoke(gameObject);
    }
}
