using UnityEngine;
using Pool;

namespace Game
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private SpawnableObject[] _spawnableObjects;
        [SerializeField] private Float _gameSpeed;
        private float _timeToNextSpawn;

        private void Awake()
        {
            _timeToNextSpawn = 0;
        }

        private void Update()
        {
            if (_gameSpeed == null)
                return;

            _timeToNextSpawn -= Time.deltaTime;

            if (_timeToNextSpawn <= 0 && _spawnableObjects != null)
            {
                foreach(var spawnableObject in _spawnableObjects)
                {
                    if (TrySpawnObject(spawnableObject))
                        break;
                }

                _timeToNextSpawn = 1 / _gameSpeed.Value;
            }

        }

        private bool TrySpawnObject(SpawnableObject spawnableObject)
        {
            var r = Random.Range(0f, 1f);
            if (r < spawnableObject.Rarity && spawnableObject.Prefab != null)
            {
                ObjectPool.Instantiate(spawnableObject.Prefab, transform.position, Quaternion.identity, transform);
                return true;
            }

            return false;
        }
    } 
}
