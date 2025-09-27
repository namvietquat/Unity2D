public class JumpState : StateBase
{
    public JumpState(PlayerController player, StateMachine stateMachine) : base(player, stateMachine)
    {
    }
    public override void Enter()
    {
        base.Enter();
        _anim.SetBool("IsGround", false);
    }
    public override void Update()
    {
        base.Update();
        if (_rb.linearVelocity.y < 0)
        {
            _stateMachine.ChangeState(_player.FallState);
        }
    }
}