using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Jumper : MonoBehaviour
    {
        private enum State
        {
            Grounded,
            Jumping,
            Falling
        }

        [SerializeField] private float _jumpForce;
        [SerializeField] private float _fastJumpMuliplier = 2f;
        [SerializeField] private float _fallMultipier = 2.5f;
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private KeyCode _jumpKey;
        [SerializeField] private UnityEvent _jumped;
        [SerializeField] private UnityEvent _grounded;
        private Rigidbody2D _rigidbody;
        private State _state;
        private bool _isBlocked;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _state = State.Grounded;
        }

        private void Update()
        {
            switch (_state)
            {
                case State.Grounded:
                    Grounded();
                    break;

                case State.Jumping:
                    Jumping();
                    break;

                case State.Falling:
                    Falling();
                    break;
            }
        }

        public void StopJumping()
        {
            _isBlocked = true;
        }

        private void Grounded()
        {
            if (Input.GetKeyDown(_jumpKey) && !_isBlocked)
            {
                _jumped?.Invoke();
                _rigidbody.AddForce(_jumpForce * Vector2.up, ForceMode2D.Impulse);
                _state = State.Jumping;
            }
        }

        private void Jumping()
        {
            if (_rigidbody.velocity.y < 0)
            {
                _state = State.Falling;
                _rigidbody.gravityScale = 1;
            }
            else if (!Input.GetKey(_jumpKey))
            {
                _rigidbody.gravityScale = _fastJumpMuliplier;
            }
            else
            {
                _rigidbody.gravityScale = 1;
            }
        }

        private void Falling()
        {
            if (IsOnGround())
            {
                _rigidbody.gravityScale = 1;
                _grounded?.Invoke();
                _state = State.Grounded;
            }
            else
            {
                _rigidbody.gravityScale = _fallMultipier;
            }
        }

        private bool IsOnGround()
        {
            return _rigidbody.IsTouchingLayers(_groundLayer);
        }
    }
}
