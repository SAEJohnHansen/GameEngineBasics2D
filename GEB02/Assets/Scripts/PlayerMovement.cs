using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Variables")]
    public float Speed;
    public float AirControl;
    public float JumpPower;

    [Header("Components")]
    public Rigidbody2D Rb;

    [Header("GroundCheck")]
    public float GroundCheckRadius;
    public LayerMask GroundLayer;
    public Transform GroundCheckPos;

    private float xAxis;
    public bool isGrounded;
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
    }

    private void FixedUpdate()
    {
        isGrounded = GroundCheck();

        Vector3 direction = new Vector3(xAxis, 0, 0);

        if (isGrounded)
        {
            Rb.velocity = new Vector2(xAxis * Speed * Time.fixedDeltaTime, Rb.velocity.y); 
        }
        else
        {
            Rb.velocity = Vector2.Lerp(Rb.velocity, new Vector2(xAxis * Speed * Time.fixedDeltaTime, Rb.velocity.y), AirControl * Time.fixedDeltaTime);
        }

    }

    public void Jump()
    {
        Rb.velocity = new Vector2(Rb.velocity.x, 0);
        Rb.AddForce(new Vector2(0, 1) * JumpPower, ForceMode2D.Impulse);
        isGrounded = false;
    }

    /// <summary>
    /// Checks for ground contact using an overlap circle and returns true if thats the case
    /// </summary>
    /// <returns></returns>
    private bool GroundCheck()
    {
        bool result = Physics2D.OverlapCircle(GroundCheckPos.position, GroundCheckRadius, GroundLayer) && Rb.velocity.y <= 0;
        return result;
    }



    /// <summary>
    /// Reset player to starting position
    /// </summary>
    public void Death()
    {
        transform.position = startPos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.CompareTag("Ground")) // Old Groundcheck
        //{
        //    isGrounded = true;
        //}

        if (collision.gameObject.CompareTag("Ouch"))
        {
            Death();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(GroundCheckPos.position, GroundCheckRadius);
    }
}
