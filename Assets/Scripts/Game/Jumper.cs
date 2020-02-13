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
        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(_jumpKey) && IsOnGround())
            {
                _rb.AddForce(_jumpForce * Vector2.up, ForceMode2D.Impulse);
            }
        }

        private void FixedUpdate()
        {
            _rb.gravityScale = (_rb.velocity.y < 0) ? _fallMultipier : ((!Input.GetKey(_jumpKey)) ? _fastJumpMuliplier : 1);
        }

        private bool IsOnGround()
        {
            return _rb.IsTouchingLayers(_groundLayer);
        }
    } 
}
