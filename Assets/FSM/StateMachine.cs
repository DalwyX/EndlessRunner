namespace FSM
{
    public class StateMachine
    {
        private IState _state;

        public void Update()
        {
            var nextState = _state?.Execute();
            if (_state != nextState)
            {
                ChangeState(nextState);
            }
        }

        public void ChangeState(IState state)
        {
            _state?.Exit();
            _state = state;
            _state?.Enter();
        }
    } 
}
