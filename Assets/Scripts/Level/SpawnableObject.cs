using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "New spawnable object", menuName = "Level/Spawnable Object")]
    public class SpawnableObject : ScriptableObject
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField, Range(0, 1)] private float _rarity;

        public GameObject Prefab => _prefab;
        public float Rarity => _rarity;
    } 
}
