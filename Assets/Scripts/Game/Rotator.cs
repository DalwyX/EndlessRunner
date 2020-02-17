using UnityEngine;

namespace Game
{
    public class Rotator : MonoBehaviour
    {
        [SerializeField] private Vector3 _rotationAxis;
        [SerializeField] private Float _baseSpeed;
        [SerializeField] private float _modifier;
        
        private void OnValidate()
        {
            _rotationAxis = _rotationAxis.normalized;
        }

        private void Update()
        {
            var rotationThisFrame = _baseSpeed.Value * _modifier * Time.deltaTime;
            transform.Rotate(_rotationAxis, rotationThisFrame);
        }
    } 
}
