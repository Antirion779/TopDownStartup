using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PoolObjectType
{
    Bullet,
    Enemies
}

[Serializable]
public class PoolInfo
{
    public PoolObjectType type;
    public int amount = 0;
    public GameObject prefab;
    public GameObject containers;

    public List<GameObject> pool = new List<GameObject>();
}

public class PoolManager : MonoBehaviour
{
    //How To Use : 
    //    All the setup is made on Unity
    //    To get An object from pool : GetObjectInPool( the PoolObjectType we want)
    //    to replace destroy =>  SendObjectBackInPool(the object to destroy, the type of object)


    public static PoolManager Instance;

    [SerializeField]
    private List<PoolInfo> listOfPool;
    
    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    void Start()
    {
        for (int i = 0; i < listOfPool.Count; i++)
        {
            FillPool(listOfPool[i]);
        }
    }

    private void FillPool(PoolInfo _info)
    {
        for(int i = 0;i < _info.amount; i++) 
        { 
            GameObject _objectInstance = Instantiate(_info.prefab, _info.containers.transform);
            _objectInstance.gameObject.SetActive(false);

            _info.pool.Add(_objectInstance);
        }
    }

    public GameObject GetObjectInPool(PoolObjectType _type)
    {
        PoolInfo _selected = GetPoolByType(_type);
        List<GameObject> _pool = _selected.pool;
        GameObject _objInstance;

        if (_pool.Count > 0) 
        {
            _objInstance = _pool[_pool.Count - 1];
            _pool.Remove(_objInstance);
        }
        else
        {
            _objInstance = Instantiate(_selected.prefab, _selected.containers.transform);
            Debug.LogWarning($"IN POOL {_selected.type}, {_selected.amount} IS NOT ENOUGHT !");
        }

        return _objInstance;
    }

    public void SendObjectBackInPool(GameObject _objInstance, PoolObjectType _type)
    {
        PoolInfo _selected = GetPoolByType(_type);
        List<GameObject> _pool = _selected.pool;

        _objInstance.gameObject.SetActive(false);

        if (!_pool.Contains(_objInstance))
            _pool.Add(_objInstance);
    }

    private PoolInfo GetPoolByType(PoolObjectType _type)
    {
        for (int i = 0; i < listOfPool.Count; i++)
        {
            if (listOfPool[i].type == _type)
                return listOfPool[i];
        }
        return null;
    } 
}

