using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectPooling : MonoBehaviour
{
    [Serializable]
    public struct Pool
    {
        public Queue<GameObject> PooledObjects;
        public GameObject poolObjectPrefab;
        public int poolSize;
    }
    [SerializeField] public Pool[] pools = null;
    private void Awake()
    {
        for (int i = 0; i < pools.Length; i++)
        {
            pools[i].PooledObjects = new Queue<GameObject>();
            var poolParent = new GameObject();
            poolParent.transform.parent = transform;
            poolParent.name = pools[i].poolObjectPrefab.ToString();

            for (int j = 0; j < pools[i].poolSize; j++)
            {
                GameObject obj = Instantiate(pools[i].poolObjectPrefab);
                obj.SetActive(false);
                pools[i].PooledObjects.Enqueue(obj);
                obj.transform.parent = poolParent.transform;

            }
        }
    }

    public GameObject GetPoolObject(int objType)
    {
        if (objType >= pools.Length)
            return null;
        if (pools[objType].PooledObjects.Count == 0)
            AddSizePool(5f, objType);

        GameObject obj = pools[objType].PooledObjects.Dequeue();
        obj.SetActive(true);
        return obj;
       
    }
    public void SetPoolObject(GameObject pooledObject, int objectType)
    {
        if (objectType >= pools.Length) return;
        pools[objectType].PooledObjects.Enqueue(pooledObject);
        pooledObject.SetActive(false);
    }

    public void AddSizePool(float amount, int objectType)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject obj = Instantiate(pools[objectType].poolObjectPrefab);
            obj.SetActive(false);
            pools[objectType].PooledObjects.Enqueue(obj);
        }
    }
}
