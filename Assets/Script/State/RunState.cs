using UnityEngine;

public class RunState : StateBase
{
    public RunState(PlayerController player, StateMachine stateMachine) : base(player, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

    }
    public override void Update()
    {
        _rb.linearVelocity = new Vector2(_player.MoveInput.x * _player.MoveSpeed, _rb.linearVelocity.y);
        if (_player.MoveInput.x == 0)
        {
            _stateMachine.ChangeState(_player.IdleState);
        }
        if (_player.JumpInput != 0)
        {
            _stateMachine.ChangeState(_player.JumpState);
        }
        base.Update();
    }
}