using UnityEngine;

namespace Game
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private SpawnableObject[] _spawnableObjects;
        [SerializeField] private Float _gameSpeed;
        [SerializeField] private float _spawnRate = 1;
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

                _timeToNextSpawn = _gameSpeed.Value / _spawnRate;
            }

        }

        private bool TrySpawnObject(SpawnableObject spawnableObject)
        {
            var r = Random.Range(0f, 1f);
            if (r < spawnableObject.Rarety && spawnableObject.Prefab != null)
            {
                Instantiate(spawnableObject.Prefab, transform.position, Quaternion.identity, transform);
                return true;
            }

            return false;
        }
    } 
}
