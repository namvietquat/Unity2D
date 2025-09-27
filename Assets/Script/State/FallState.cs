public class FallState : StateBase
{
    public FallState(PlayerController player, StateMachine stateMachine) : base(player, stateMachine)
    {
    }

    public override void Update()
    {
        base.Update();
        if (_player.IsGroundDetect)
        {
            _stateMachine.ChangeState(_player.IdleState);
        }
    }
}