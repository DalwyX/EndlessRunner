using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class ObjectPool : MonoBehaviour
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

            int nextInactiveObject = Expand(go, root);
            return SetParams(_pool[go][nextInactiveObject].Get(), pos, rot, root);
        }

        private GameObject SetParams(GameObject go, Vector2 pos, Quaternion rot, Transform root)
        {
            go.transform.position = pos;
            go.transform.rotation = rot;
            go.transform.parent = root;
            return go;
        }

        private int Expand(GameObject go, Transform objTransform)
        {
            int count = _pool[go].Count;
            for (int i = 0; i < count; i++)
            {
                _pool[go].Add(new PooledObject(go, objTransform));
            }
            return count;
        }
    }
}
