using UnityEngine;

namespace Game
{
    public class PooledObject
    {
        private GameObject _gameObject;
        public bool IsActive => _gameObject.activeInHierarchy;
        public bool StillExists => _gameObject != null;

        public PooledObject(GameObject go, Transform transform)
        {
            _gameObject = Object.Instantiate(go, transform);
            _gameObject.SetActive(false);
        }

        public GameObject Get()
        {
            _gameObject.SetActive(true);
            return _gameObject;
        }
    } 
}