using FSM;

namespace Jumping
{
    public class FallingState : IState<Jumper>
    {
        public void Enter(StateMachine<Jumper> stateMachine, Jumper owner)
        {
            owner.Animator.SetTrigger("InAir");
            owner.Rigidbody.gravityScale = owner.FallMultipier;
        }

        public void Execute(StateMachine<Jumper> stateMachine, Jumper owner)
        {
            if (owner.IsOnGround())
            {
                stateMachine.ChangeState(typeof(GroundedState));
            }
        }

        public void Exit(StateMachine<Jumper> stateMachine, Jumper owner)
        {
            owner.Animator.ResetTrigger("InAir");
            owner.Rigidbody.gravityScale = 1;
        }
    }
}
