using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class PoolTest : MonoBehaviour
    {
        [Button]
        void SpawnBullet()
        {
            StartCoroutine(GenerateObjFromPool(PoolObjectType.Bullet));
        }

        [Button]
        private void SpawnEnemies()
        {
            StartCoroutine(GenerateObjFromPool(PoolObjectType.Enemies));
        }

        private IEnumerator GenerateObjFromPool(PoolObjectType _type)
        {
            GameObject _obj = PoolManager.Instance.GetObjectInPool(_type);
            _obj.transform.position = new Vector2(Random.Range(-3,3), Random.Range(-3, 3));
            _obj.gameObject.SetActive(true);

            yield return new WaitForSeconds(3);

            PoolManager.Instance.SendObjectBackInPool(_obj, _type);
        }
    }
}
