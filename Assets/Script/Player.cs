using System;
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

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        if (_rb == null)
        {
            Debug.LogError("Rigidbody2D chua duoc gan vao Player!");
        }
    }
    void Update()
    {
        
    
    }
    void FixedUpdate()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        Flip(_horizontalInput);
        GroundCheck();

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
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.2f, GroundLayerMask);
        Debug.DrawRay(transform.position, Vector2.down * 1.2f, Color.red);
        _isOnAir = hit.collider == null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Va cham voi: " + collision.name);
    }
}
