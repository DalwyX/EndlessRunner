using UnityEngine;
using FSM;

namespace Jumping
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
    public class Jumper : MonoBehaviour
    {
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _fastJumpMuliplier = 2f;
        [SerializeField] private float _fallMultipier = 2.5f;
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private KeyCode _jumpKey;
        private StateMachine<Jumper> _state;
        private bool _isBlocked;

        public Rigidbody2D Rigidbody { get; private set; }
        public Animator Animator { get; private set; }
        public float JumpForce => _jumpForce;
        public float FastJumpMuliplier => _fastJumpMuliplier;
        public float FallMultipier => _fallMultipier;
        public KeyCode JumpKey => _jumpKey;

        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody2D>();
            Animator = GetComponent<Animator>();
            _state = new StateMachine<Jumper>(this);
            _state.ChangeState(typeof(GroundedState));
        }

        private void Update()
        {
            if (_isBlocked) return;

            _state.Update();
        }

        public void BlockJumper()
        {
            _isBlocked = true;
        }

        public bool IsOnGround()
        {
            return Rigidbody.IsTouchingLayers(_groundLayer);
        }
    }
}
