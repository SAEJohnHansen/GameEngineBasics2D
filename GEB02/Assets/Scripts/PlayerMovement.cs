using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    public float JumpPower;
    public Rigidbody2D Rb;

    private float xAxis;
    private bool isGrounded;
    private Vector2 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        xAxis = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded) // Jump Input and Check if we can jump
        {
            Jump();
        }

        //if (Input.GetButtonDown("Fire1") && !isGrounded)
        //{
        //    AirAttack();
        //}
    }

    private void FixedUpdate()
    {
        Vector3 direction = new Vector3(xAxis, 0, 0);
        //transform.Translate(direction * Speed * Time.fixedDeltaTime);
        Rb.velocity = new Vector2(xAxis * Speed * Time.fixedDeltaTime, Rb.velocity.y);
    }
    public void Jump()
    {
        Rb.velocity = new Vector2(Rb.velocity.x, 0);
        Rb.AddForce(new Vector2(0, 1) * JumpPower, ForceMode2D.Impulse);
        isGrounded = false;
    }

    public void Death()
    {
        transform.position = startPos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Ouch"))
        {
            Death();
        }
    }
}
