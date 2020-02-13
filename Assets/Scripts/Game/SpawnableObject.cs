using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "New spawnable object", menuName = "Level/Spawnable Object")]
    public class SpawnableObject : ScriptableObject
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField, Range(0, 1)] private float _rarety;
        [SerializeField] private Vector2 _verticalSpawnOffsetRange;
        [SerializeField] private Vector2 _horizontalSpawnOffsetRange;

        public GameObject Prefab => _prefab;
        public float Rarety => _rarety;

        public Vector3 GetSpawnOffset()
        {
            var minVertical = (_verticalSpawnOffsetRange.x < _verticalSpawnOffsetRange.y) ? _verticalSpawnOffsetRange.x : _verticalSpawnOffsetRange.y;
            var maxVertical = (minVertical == _verticalSpawnOffsetRange.x) ? _verticalSpawnOffsetRange.y : _verticalSpawnOffsetRange.x;
            var verticalOffset = Random.Range(minVertical, maxVertical);

            var minHorizontal = (_horizontalSpawnOffsetRange.x < _horizontalSpawnOffsetRange.y) ? _horizontalSpawnOffsetRange.x : _horizontalSpawnOffsetRange.y;
            var maxHorizontal = (minHorizontal == _horizontalSpawnOffsetRange.x) ? _horizontalSpawnOffsetRange.y : _horizontalSpawnOffsetRange.x;
            var horizontalOffset = Random.Range(minHorizontal, maxHorizontal);

            return new Vector3(horizontalOffset, verticalOffset);
        }
    } 
}
