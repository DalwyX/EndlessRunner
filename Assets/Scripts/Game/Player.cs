using UnityEngine;

namespace Game
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Float _baseSpeed;
        [SerializeField] private float _startingSpeed;
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _accelerationPerSecond;

        private void Start()
        {
            _baseSpeed?.SetValue(_startingSpeed);
        }

        private void Update()
        {
            var accelerationThisFrame = _accelerationPerSecond * Time.deltaTime;
            var speed = Mathf.Clamp(_baseSpeed.Value + accelerationThisFrame, _startingSpeed, _maxSpeed);
            _baseSpeed?.SetValue(speed);
        }
    } 
}
