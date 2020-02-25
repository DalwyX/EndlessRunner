using UnityEngine;
using FSM;

namespace Jumping
{
    public class GroundedState : IState<Jumper>
    {
        private Rigidbody2D _rigidbody;
        private Animator _animator;

        public void Enter(StateMachine<Jumper> stateMachine, Jumper owner)
        {
            _rigidbody = owner.Rigidbody;
            _animator = owner.Animator;
            _animator.SetTrigger("Grounded");
        }

        public void Execute(StateMachine<Jumper> stateMachine, Jumper owner)
        {
            if (_rigidbody.velocity.y > 0)
            {
                stateMachine.ChangeState(typeof(JumpingState));
            }
            if (_rigidbody.velocity.y < 0)
            {
                stateMachine.ChangeState(typeof(FallingState));
            }

            if (Input.GetKeyDown(owner.JumpKey))
            {
                owner.Rigidbody.AddForce(owner.JumpForce * Vector2.up, ForceMode2D.Impulse);
            }
        }

        public void Exit(StateMachine<Jumper> stateMachine, Jumper owner)
        {
            _animator.ResetTrigger("Grounded");
        }
    } 
}
