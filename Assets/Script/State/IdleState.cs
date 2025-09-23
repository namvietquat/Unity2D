using UnityEngine;

public class IdleState : StateBase
{
    protected Player _player;
    public IdleState(Player player)
    {
        _player = player;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Enter()
    {
        
    }

    // Update is called once per frame
    public override void Exit()
    {
        
    }

    public override void Update()
    {
        if (Player.MoveInput.x != 0)
        {
            Player.StateMachine.ChangeState(new RunState());
        }

        if (_player.JumpInput != 0)
        {
            _player.StateMachine.ChangeState(new JumpState());
        }
    }
}
