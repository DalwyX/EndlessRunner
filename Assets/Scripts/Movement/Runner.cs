using UnityEngine;

namespace Movement
{
    public class Runner : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Vector2 _moveDirection;
        private bool _isBlocked;

        private void OnValidate()
        {
            _speed = Mathf.Clamp(_speed, 0, Mathf.Infinity);
            _moveDirection = _moveDirection.normalized;
        }

        private void Update()
        {
            if (_isBlocked)
                return;

            var transition = _speed * Time.deltaTime * _moveDirection;
            transform.Translate(transition);
        }

        public void StopMovement()
        {
            _isBlocked = true;
        }
    } 
}
