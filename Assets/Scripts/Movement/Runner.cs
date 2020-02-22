using UnityEngine;

namespace Movement
{
    public class Runner : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Vector2 _moveDirection;

        private void OnValidate()
        {
            _speed = Mathf.Clamp(_speed, 0, Mathf.Infinity);
            _moveDirection = _moveDirection.normalized;
        }

        private void Update()
        {
            var translation = _speed * Time.deltaTime * _moveDirection;
            transform.Translate(translation);
        }
    } 
}
