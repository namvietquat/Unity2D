using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float Speed = 3;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        _rb.linearVelocity = new Vector2(horizontalInput * Speed, _rb.linearVelocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("va cham");
    }
}