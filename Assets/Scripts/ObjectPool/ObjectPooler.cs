using System.Collections.Generic;
using UnityEngine;

namespace ObjectPool
{
    public class ObjectPooler : MonoBehaviour
    {
        private Dictionary<GameObject, List<PooledObject>> _pool = new Dictionary<GameObject, List<PooledObject>>();

        public GameObject Instantiate(GameObject go, Vector2 pos, Quaternion rot, Transform root)
        {

            if (!_pool.ContainsKey(go))
            {
                _pool.Add(go, new List<PooledObject>());
                _pool[go].Add(new PooledObject(go, root));
            }

            foreach (PooledObject po in _pool[go])
            {
                if (!po.StillExists)
                {
                    _pool[go].Remove(po);
                }
                if (!po.IsActive)
                {
                    return SetParams(po.Get(), pos, rot, root);
                }
            }

            var newObject = new PooledObject(go, root);
            _pool[go].Add(newObject);
            return SetParams(newObject.Get(), pos, rot, root);
        }

        private GameObject SetParams(GameObject go, Vector2 pos, Quaternion rot, Transform root)
        {
            go.transform.position = pos;
            go.transform.rotation = rot;
            go.transform.parent = root;
            return go;
        }
    }
}
