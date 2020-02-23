using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Jumper : MonoBehaviour
    {
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _fastJumpMuliplier = 2f;
        [SerializeField] private float _fallMultipier = 2.5f;
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private KeyCode _jumpKey;
        private Rigidbody2D _rigidbody;
        private bool _isBlocked;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(_jumpKey) && IsOnGround() && !_isBlocked)
            {
                _rigidbody.AddForce(_jumpForce * Vector2.up, ForceMode2D.Impulse);
            }
        }

        private void FixedUpdate()
        {
            if (_rigidbody.velocity.y < 0)
            {
                _rigidbody.gravityScale = _fallMultipier;
            }
            else if (_rigidbody.velocity.y > 0 && !Input.GetKey(_jumpKey))
            {
                _rigidbody.gravityScale = _fastJumpMuliplier;
            }
            else
            {
                _rigidbody.gravityScale = 1;
            }
        }

        public void StopJumping()
        {
            _isBlocked = true;
        }

        private bool IsOnGround()
        {
            return _rigidbody.IsTouchingLayers(_groundLayer);
        }
    }
}
