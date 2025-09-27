public class StateMachine
{
    private StateBase _currentState; // field - trường
    public StateBase CurrentState => _currentState;// property - thuộc tính
 
    public void ChangeState(StateBase newState)
    {
        // null checkccccccccccccccccccccccccccccccccccccccc
        if (newState == null)
        {
            return;
        }

        _currentState?.Exit();
        _currentState = newState;
        _currentState.Enter();
    }
}
