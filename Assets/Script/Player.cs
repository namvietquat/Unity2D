using System;
using TMPro;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float Speed = 3f;
    public float JumpForce = 3f;
    private bool _isOnAir;
    private float _horizontalInput;
    public LayerMask GroundLayerMask;
    private Animator _anim;
    public float distance = 1.5f;

    void Start()
    {
      
    }
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }
    void Update()
    {
        HandleAnimation();
        Flip(_horizontalInput);
        GroundCheck();

    }
    void FixedUpdate()
    {
   
        // Di chuyen ngang
        _rb.linearVelocity = new Vector2(_horizontalInput * Speed, _rb.linearVelocity.y);
    }
    public void Move(CallbackContext ctx)
    {
       
        Vector2 movement = ctx.ReadValue<Vector2>();
        
        _horizontalInput = movement.x;

    }
    public void Jump(CallbackContext ctx)
    {
        if (_isOnAir) return;

        
        float jumpInput = ctx.ReadValue<float>();

        _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, jumpInput * JumpForce);
        
        _isOnAir = true;
    }

    void Flip(float direction)
    {
        if (direction == 0) return;

        if ((direction > 0) != (transform.localScale.x > 0))
        {
            transform.localScale *= new Vector2(-1f, 1f);
        }
    }

    void GroundCheck()
    {
        if (Physics2D.Raycast(transform.position, Vector2.down, distance, GroundLayerMask))
        {
            _isOnAir = false;
            _anim.SetBool("IsGround", true);
        }
        else
        {
            _isOnAir = true;
            _anim.SetBool("IsGround", false);
        }

    }

   void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position - new Vector3(0f, distance, 0f));
    }
    void HandleAnimation()
    {
        _anim.SetFloat("xInput", _horizontalInput);
        _anim.SetFloat("yInput", _rb.linearVelocity.y);
    }
    public void Attack()
    {
        _anim.SetTrigger
    }
}
