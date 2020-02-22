using System.Collections.Generic;
using UnityEngine;

namespace Pool
{
    public static class ObjectPool
    {
        private static Dictionary<GameObject, List<GameObject>> _pool = new Dictionary<GameObject, List<GameObject>>();

        public static GameObject Instantiate(GameObject gameObject, Vector2 position, Quaternion rotation, Transform root)
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

        private static GameObject AddObject(GameObject gameObject)
        {
            var newObject = Object.Instantiate(gameObject);
            _pool[gameObject].Add(newObject);
            return newObject;
        }

        private static GameObject SetParams(GameObject go, Vector2 pos, Quaternion rot, Transform root)
        {
            go.transform.parent = root;
            go.transform.position = pos;
            go.transform.rotation = rot;
            go.SetActive(true);
            return go;
        }
    }
}
