using UnityEngine;

namespace Game
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private Float _baseSpeed;
        [SerializeField] private float _speedModifier = 1;
        [SerializeField] private Vector2 _moveDirection;

        private void OnValidate()
        {
            _moveDirection = _moveDirection.normalized;
        }

        private void Update()
        {
            if (_baseSpeed == null)
                return;

            var translation = _baseSpeed.Value * _speedModifier * Time.deltaTime * _moveDirection;
            transform.Translate(translation, Space.World);
        }
    } 
}
