using UnityEngine;
using FSM;

namespace Jumping
{
    public class JumpingState : IState<Jumper>
    {
        private Rigidbody2D _rigidbody;
        private Animator _animator;

        public void Enter(StateMachine<Jumper> stateMachine, Jumper owner)
        {
            _rigidbody = owner.Rigidbody;
            _animator = owner.Animator;
            _animator.SetTrigger("InAir");
        }

        public void Execute(StateMachine<Jumper> stateMachine, Jumper owner)
        {
            if (_rigidbody.velocity.y < 0)
            {
                stateMachine.ChangeState(typeof(FallingState));
            }

            _rigidbody.gravityScale = (Input.GetKey(owner.JumpKey)) ? 1 : owner.FastJumpMuliplier;
        }

        public void Exit(StateMachine<Jumper> stateMachine, Jumper owner)
        {
            _rigidbody.gravityScale = 1;
            _animator.ResetTrigger("InAir");
        }
    } 
}
