using UnityEngine;

namespace Level
{
    [System.Serializable]
    public class SpawnableObject
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField, Range(0, 1)] private float _frequency;

        public GameObject Prefab => _prefab;
        public float Frequency => _frequency;
    }
}
