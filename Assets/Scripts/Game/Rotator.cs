using UnityEngine;

namespace Game
{
    public class Rotator : MonoBehaviour
    {
        [SerializeField] private Vector3 _rotationAxis;
        [SerializeField] private Float _baseSpeed;
        [SerializeField] private float _modifier;

        private void Awake()
        {
            _rotationAxis = _rotationAxis.normalized;
        }

        private void FixedUpdate()
        {
            transform.Rotate(_rotationAxis, _baseSpeed.Value * _modifier);
        }
    } 
}
