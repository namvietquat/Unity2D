public class IdleState : StateBase
{
    public IdleState(PlayerController player, StateMachine stateMachine) : base(player, stateMachine)
    {
    }

    public override void Enter()
    {

    }

    public override void Exit()
    {

    }

    public override void Update()
    {
        base.Update();
        if (_player.MoveInput.x != 0)
        {
            _stateMachine.ChangeState(_player.RunState);
        }
        if (_player.JumpInput != 0)
        {
            _player.JumpInput = 0f;
            _stateMachine.ChangeState(_player.JumpState);
        }
    }
}