using System;
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

        private void Awake()
        {
            if (_baseSpeed == null)
            {
                throw new NullReferenceException("_baseSpeed not assigned in " + this);
            }
        }

        private void Update()
        {
            var translation = _baseSpeed.Value * _speedModifier * Time.deltaTime * _moveDirection;
            transform.Translate(translation, Space.World);
        }
    } 
}
