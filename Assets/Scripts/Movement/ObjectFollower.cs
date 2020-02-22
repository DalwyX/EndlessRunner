using UnityEngine;

namespace Movement
{
    public class ObjectFollower : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Vector3 _offset;
        [SerializeField] private bool _lockXAxis;
        [SerializeField] private bool _lockYAxis;
        [SerializeField] private bool _lockZAxis;

        private void LateUpdate()
        {
            var x = (_lockXAxis) ? transform.position.x : _target.position.x + _offset.x;
            var y = (_lockYAxis) ? transform.position.y : _target.position.y + _offset.y;
            var z = (_lockZAxis) ? transform.position.z : _target.position.z + _offset.z;
            transform.position = new Vector3(x, y, z);
        }
    } 
}
