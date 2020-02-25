namespace FSM
{
    public interface IState
    {
        void Enter();
        IState Execute();
        void Exit();
    } 
}
