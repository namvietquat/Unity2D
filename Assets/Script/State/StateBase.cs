using System;
using UnityEngine;

[Serializable]
public class StateBase // POCO: Plain old c# object
{
    protected PlayerController _player;
    protected StateMachine _stateMachine;
    protected Rigidbody2D _rb;
    protected Animator _anim;
    public StateBase(PlayerController playerController, StateMachine stateMachine)
    {
        _player = playerController;
        _stateMachine = stateMachine;
        _rb = _player.RB;
        _anim = _player.Anim;
    }
    public virtual void Enter()
    {

    }

    public virtual void Exit()
    {

    }

    public virtual void Update()
    {
        HandleAnimation();
    }

    private void HandleAnimation()
    {
        _anim.SetFloat("xInput", _player.MoveInput.x);
        _anim.SetFloat("yInput", _player.JumpInput);
        if (_player.IsGroundDetect)
        {
            _anim.SetBool("IsGround", true);
        }
        else
        {
            _anim.SetBool("IsGround", false);
        }
    }
}