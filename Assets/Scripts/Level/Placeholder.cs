using UnityEngine;

namespace Level
{
    public class Placeholder : MonoBehaviour
    {
        [SerializeField] private SpawnableObject[] _spawnableObjects;
        [SerializeField] private Vector2 _visualSize;

        public GameObject GetPrefab()
        {
            var random = Random.Range(0f, 1f);
            var probabilities = GetProbabilies();
            var cumulativeProbability = 0f;

            for (var i = 0; i < _spawnableObjects.Length; i++)
            {
                cumulativeProbability += probabilities[i];
                if (random <= cumulativeProbability)
                {
                    return _spawnableObjects[i].Prefab;
                }
            }

            return null;
        }

        private float[] GetProbabilies()
        {
            var overallFrequency = 0f;
            foreach (var spawnableOjbect in _spawnableObjects)
            {
                overallFrequency += spawnableOjbect.Frequency;
            }

            var probabilities = new float[_spawnableObjects.Length];

            for (int i = 0; i < _spawnableObjects.Length; i++)
            {
                probabilities[i] = _spawnableObjects[i].Frequency / overallFrequency;
            }

            return probabilities;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireCube(transform.position, _visualSize);
        }
    }
}
