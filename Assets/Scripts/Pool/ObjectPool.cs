using System.Collections.Generic;
using UnityEngine;

namespace Pool
{
    public class ObjectPool : MonoBehaviour
    {
        private Dictionary<GameObject, List<GameObject>> _pool = new Dictionary<GameObject, List<GameObject>>();

        public GameObject SpawnObject(GameObject gameObject, Vector2 position, Quaternion rotation)
        {
            return SpawnObject(gameObject, position, rotation, transform);
        }

        public GameObject SpawnObject(GameObject gameObject, Vector2 position, Quaternion rotation, Transform root)
        {
            if (!_pool.ContainsKey(gameObject))
            {
                _pool.Add(gameObject, new List<GameObject>());
            }

            foreach (var pooledObject in _pool[gameObject])
            {
                if (pooledObject == null)
                {
                    _pool[gameObject].Remove(pooledObject);
                }
                if (!pooledObject.activeInHierarchy)
                {
                    return SetParams(pooledObject, position, rotation, root);
                }
            }

            var newObject = AddObject(gameObject);
            return SetParams(newObject, position, rotation, root);
        }

        private GameObject AddObject(GameObject gameObject)
        {
            var newObject = Instantiate(gameObject);
            _pool[gameObject].Add(newObject);
            return newObject;
        }

        private GameObject SetParams(GameObject gameObject, Vector2 position, Quaternion rotation, Transform root)
        {
            gameObject.transform.parent = root;
            gameObject.transform.position = position;
            gameObject.transform.rotation = rotation;
            gameObject.SetActive(true);
            return gameObject;
        }
    }
}
