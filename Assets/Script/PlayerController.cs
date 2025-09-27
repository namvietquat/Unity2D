using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    private Player _player;
    private StateMachine _stateMachine;
    private InputSystem_Actions _inputActions;
    private Rigidbody2D _rb;
    public Rigidbody2D RB => _rb;
    private Animator _animator;
    public Animator Anim => _animator;
    private Vector2 _moveInput;
    private float _jumpInput;
    private bool _isGroundDetect;
    public bool IsGroundDetect => _isGroundDetect;
    [SerializeField]
    private float _moveSpeed = 5f;
    [SerializeField]
    private float _jumpForce = 2f;
    [SerializeField]
    private float _detectGroundDistance = 1.5f;
    public Vector2 MoveInput => _moveInput;
    public float JumpInput
    {
        get => _jumpInput;
        set => _jumpInput = value;
    }
    public float JumpForce => _jumpForce;
    public StateMachine StateMachine => _stateMachine;

    public float MoveSpeed => _moveSpeed;

    private LayerMask _ignoreLayer;

    public IdleState IdleState;
    public RunState RunState;
    public JumpState JumpState;
    public FallState FallState;
    public StateBase CurrentState;

    void Awake()
    {
        _player = GetComponent<Player>();
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _ignoreLayer = LayerMask.GetMask("Ground");
        _stateMachine = new StateMachine();

        IdleState = new IdleState(this, _stateMachine);
        RunState = new RunState(this, _stateMachine);
        JumpState = new JumpState(this, _stateMachine);
        FallState = new FallState(this, _stateMachine);
        _stateMachine.ChangeState(IdleState);
    }

    void Start()
    {

    }

    void Update()
    {
        _stateMachine.CurrentState.Update();
        CurrentState = _stateMachine.CurrentState;
    }

    void FixedUpdate()
    {
        DetectGround();
    }
    public void Move(InputAction.CallbackContext ctx)
    {
        _moveInput = ctx.ReadValue<Vector2>();
        SetFacingDirection(_moveInput.x);
    }
    public void Jump(InputAction.CallbackContext ctx)
    {
        if (!_isGroundDetect)
        {
            return;
        }
        Debug.Log("On Jump");

        _isGroundDetect = false;
        _jumpInput = ctx.ReadValue<float>();
        _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, _jumpForce * _jumpInput);
    }

    private void SetFacingDirection(float direction)
    {
        if (direction == 0)
        {
            return;
        }
        if (direction > 0 != transform.localScale.x > 0)
        {
            transform.localScale *= new Vector2(-1f, 1f);
        }
    }

    private void DetectGround()
    {
        List<RaycastHit2D> hit = new();
        var filter = new ContactFilter2D
        {
            layerMask = _ignoreLayer,
            useLayerMask = true
        };
        if (Physics2D.Raycast(transform.position, Vector2.down, filter, hit, _detectGroundDistance) > 0)
        {
            _isGroundDetect = true;
        }
        else
        {
            _isGroundDetect = false;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * _detectGroundDistance);
    }
}
