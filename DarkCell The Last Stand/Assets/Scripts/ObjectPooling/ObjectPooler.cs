using UnityEngine;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class ObjectPool
    {
        public string objectName;
        public GameObject objectPrefab;
        public int objectSize;
    }

    public ObjectPool[] pools;
    public Dictionary<string, Queue<GameObject>> poolOfDictionary;

    void Start()
    {
        poolOfDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach(ObjectPool pool in pools)
        {
            Queue<GameObject> obj = new Queue<GameObject>();

            for(int i = 0;i<pool.objectSize;i++)
            {
                GameObject objPool = Instantiate(pool.objectPrefab);
                objPool.SetActive(false);
                obj.Enqueue(objPool);
            }
            poolOfDictionary.Add(pool.objectName, obj);
        }
    }

    public GameObject SpawnFromPools(string tag, Vector3 position, Quaternion rotation)
    {
        GameObject objToSpawn = poolOfDictionary[tag].Dequeue();
        objToSpawn.SetActive(true);
        objToSpawn.transform.position = position;
        objToSpawn.transform.rotation = rotation;

        poolOfDictionary[tag].Enqueue(objToSpawn);

        return objToSpawn;
    }
}