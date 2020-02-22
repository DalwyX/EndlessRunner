using UnityEngine;
using Pool;

namespace Level
{
    public class LevelGenerator : MonoBehaviour
    {
        [SerializeField] private GameObject[] _chunks;
        [SerializeField] private float _chunkSize;
        [SerializeField] private ObjectPool _objectPool;
        private int _lastSpawnPosition;

        private void Start()
        {
            _lastSpawnPosition = WorldToGrid(transform.position.x);
        }

        private void Update()
        {
            var gridPosition = WorldToGrid(transform.position.x);

            if (gridPosition > _lastSpawnPosition && _chunks != null)
            {
                for (var x = _lastSpawnPosition; x < gridPosition; x++)
                {
                    TrySpawnChunk(x);
                }

                _lastSpawnPosition = gridPosition;
            }
        }

        private void TrySpawnChunk(int gridPosition)
        {
            var r = Random.Range(0, _chunks.Length);
            var chunk = _chunks[r];
            var position = transform.position;
            position.x = GridToWorld(gridPosition);

            foreach (var chunkElement in chunk.GetComponentsInChildren<Placeholder>(true))
            {
                var spawnableObject = chunkElement.GetPrefab();
                if (spawnableObject == null) continue;

                var spawnPosition = position + chunkElement.transform.position;

                _objectPool.SpawnObject(spawnableObject, spawnPosition, Quaternion.identity);
            }
        }

        private int WorldToGrid(float position)
        {
            return (int)(position / _chunkSize);
        }

        private float GridToWorld(int position)
        {
            return position * _chunkSize;
        }
    }
}
