using UnityEditor;
using UnityEngine;

public class StateMachine
{
   private StateBase _currentState; // fied public StateBase CurrentState

   public StateBase CurrentState;


    public void ChangeState(StateBase newState)
    {
        _currentState?.Exit();
        _currentState = newState;
        _currentState?.Enter();
    }
}
