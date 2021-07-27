using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Adarsh.Poolsystem
{

    public interface ISimplePooler
    {
        int PoolCount { get; }
        GameObject GetObject(bool value);
        T GetObject<T>(bool value);
        void AddObject();
        List<GameObject> GetAllObjects();
        void GetBackToPool(GameObject go);
        void ReturnAllToPool();
        List<GameObject> GetActiveObjects();
        void DestroyPool();
    }

    public class SimplePooler : ISimplePooler
    {

        private Transform parent;
        private int poolSize;
        private GameObject prefab;
        private List<GameObject> storage;

        public int PoolCount
        {
            get
            {
                return storage == null ? -1 : storage.Count;
            }
        }

        public SimplePooler(GameObject prefab, int poolSize, Transform parent)
        {
            this.prefab = prefab;
            this.poolSize = poolSize;
            this.parent = parent;
            Init();
        }

        public SimplePooler() { }

        /// <summary>
        /// Pool Initialization
        /// </summary>
        private void Init()
        {
            storage = new List<GameObject>();

            if (poolSize <= 0) poolSize = 1;

            if (prefab != null && parent != null)
                CreateObjects();
            else
                Debug.LogError("Prefab or Parent should not be null.");
        }

        /// <summary>
        /// Creates Objects to Pool.
        /// </summary>
        private void CreateObjects()
        {
            for (int i = 0; i < poolSize; i++)
            {
                AddObject().SetActive(false);
            }
        }

        /// <summary>
        /// Adds new gameobject to Pool.
        /// </summary>
        /// <returns></returns>
        private GameObject AddObject()
        {
            var go = GameObject.Instantiate(prefab) as GameObject;
            go.transform.SetParent(parent, false);
            storage.Add(go);
            return go;
        }

        /// <summary>
        /// Returns inactive gameobject from the Pool.
        /// </summary>
        /// <returns></returns>
        private GameObject GetObjectFromPool(bool value)
        {
            GameObject go = null;

            for (int i = 0; i < storage.Count; i++)
            {
                if (!storage[i].activeSelf)
                {
                    go = storage[i];
                    break;
                }
            }

            if (go == null)
            {
                var newObject = AddObject();
                newObject.SetActive(value);
                return newObject;
            }

            go.SetActive(value);
            return go;
        }

        /// <summary>
        /// Returns Gameobject from Pool.
        /// </summary>
        /// <returns></returns>
        public GameObject GetObject(bool value)
        {
            return GetObjectFromPool(value);
        }

        /// <summary>
        /// Returns Component of the object from the Pool.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetObject<T>(bool value)
        {
            return GetObjectFromPool(value).GetComponent<T>();
        }

        /// <summary>
        /// Adds new Gameobject to Pool.
        /// </summary>
        void ISimplePooler.AddObject()
        {
            AddObject();
        }

        /// <summary>
        /// Return All the Pool Objects.
        /// </summary>
        /// <returns></returns>
        public List<GameObject> GetAllObjects()
        {
            return storage;
        }

        /// <summary>
        /// Throw gameobject to pool manually to use again.
        /// </summary>
        /// <param name="go"></param>
        public void GetBackToPool(GameObject go)
        {
            go.transform.SetParent(parent, false);
            go.SetActive(false);
        }

        public void ReturnAllToPool()
        {
            if (storage != null)
            {
                foreach (var item in storage)
                {
                    item.SetActive(false);
                    item.transform.SetParent(parent, false);
                }   
            }
        }

        public void DestroyPool()
        {
            if (storage != null)
            {
                foreach (var item in storage)
                {
                    GameObject.Destroy(item);
                }
                storage.Clear();
                storage.Capacity = 4;   
            }
        }

        public List<GameObject> GetActiveObjects()
        {
            List<GameObject> objects = new List<GameObject>();
            foreach (var item in storage)
            {
                if (item.activeSelf)
                {
                    objects.Add(item);
                }
            }
            return objects;
        }
    }
}

public interface IDictionaryPool
{
    GameObject GetObject(int key, GameObject _prefab = null);
    void GetBackToPool(GameObject go);
    void ReturnAllToPool();
}

public class DictionaryPool : IDictionaryPool
{
    private Dictionary<int, List<GameObject>> collection;
    private Transform parent;
    private GameObject prefab;

    public DictionaryPool(GameObject prefab, Transform parent)
    {
        if (parent != null)
            this.parent = parent;
        this.prefab = prefab;
        collection = new Dictionary<int, List<GameObject>>();
    }

    public DictionaryPool()
    {
        collection = new Dictionary<int, List<GameObject>>();
    }

    public GameObject GetObject(int key, GameObject _prefab = null)
    {
        if (collection.ContainsKey(key))
        {
            var list = collection[key];

            foreach (var obj in list)
            {
                var go = obj as GameObject;

                if (!go.activeSelf)
                    return obj;
            }

            Create(list, _prefab);
            return list[list.Count - 1];
        }

        var pool = new List<GameObject>();
        Create(pool, _prefab);
        collection.Add(key, pool);
        return pool[0];
    }

    public void GetBackToPool(GameObject go)
    {
        if (parent != null)
            go.transform.SetParent(parent, false);
        go.SetActive(false);
    }

    public void ReturnAllToPool()
    {
        var values = collection.Values;
        foreach (var value in values)
        {
            foreach (var item in value)
            {

                item.SetActive(false);
            }
        }
    }

    private void Create(List<GameObject> list, GameObject _prefab)
    {
        var go = Create(_prefab);
        list.Add(go);
    }

    private GameObject Create(GameObject _prefab)
    {
        GameObject obj;
        if (_prefab != null)
            obj = GameObject.Instantiate(_prefab);
        else
            obj = GameObject.Instantiate(prefab);

        obj.SetActive(false);
        if (parent != null)
            obj.transform.SetParent(parent, false);

        //var component = obj.GetComponent<GameObject>();
        return obj;
    }
}
