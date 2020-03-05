using UnityEngine;

namespace FSM
{
    public interface IState<T> where T : MonoBehaviour
    {
        void Enter(StateMachine<T> stateMachine, T owner);
        void Execute(StateMachine<T> stateMachine, T owner);
        void Exit(StateMachine<T> stateMachine, T owner);
    } 
}
