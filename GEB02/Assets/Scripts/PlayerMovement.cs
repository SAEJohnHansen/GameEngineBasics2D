using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Variables")]
    public PlayerSettings settings;
    public float Speed;
    public float AirControl;
    public float JumpPower;

    [Header("Components")]
    public Rigidbody2D Rb;
    public SpriteRenderer SpRend;
    public Animator Anim;

    [Header("GroundCheck")]
    public float GroundCheckRadius;
    public LayerMask GroundLayer;
    public Transform GroundCheckPos;

    private float xAxis;
    public bool isGrounded;
    private Vector2 startPos;

    private void Awake()
    {
        Speed = settings.speed;
        AirControl = settings.airControl;
        JumpPower = settings.jumpPower;
    }

    private void Start()
    {
        SpRend = GetComponent<SpriteRenderer>();
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        xAxis = Input.GetAxis("Horizontal");
        Anim.SetFloat("Speed", Mathf.Abs(xAxis));
        Anim.SetFloat("YVelocity", Rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded) // Jump Input and Check if we can jump
        {
            Jump();
        }

        FlipCharacter();
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

    private void FlipCharacter()
    {
        if (xAxis > 0.1f)
        {
            SpRend.flipX = false;
        }
        if (xAxis < -0.1f)
        {
            SpRend.flipX = true;
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
        bool result = Physics2D.OverlapCircle(GroundCheckPos.position, GroundCheckRadius, GroundLayer) && Rb.velocity.y <= 1;
        return result;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(GroundCheckPos.position, GroundCheckRadius);
    }
}
