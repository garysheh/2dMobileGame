using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed;

    public float jumpForce;

    [Header("Ground Check")]

    public Transform groundCheck;
    public float checkRadius;
    public LayerMask groundLayer;

    [Header("Status Check")]
    public bool isGround;
    public bool isJump;
    public bool canJump;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
    }

    public void FixedUpdate()
    {
        PhysicsCheck();
        Movement();
        Jump();
    }

    void CheckInput()
    {
        if(Input.GetButtonDown("Jump") && isGround)
        {
            canJump = true;
        }
    }

    void Movement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal"); // -1 ~ 1 included decimal
        // float horizontalInput = Input.GetAxis("Horizontal"); // decline movement delay

        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

        if(horizontalInput != 0)
        {
            transform.localScale = new Vector3(horizontalInput, 1, 1);
        }
    }

    void Jump()
    {
        if(canJump)
        {
            isJump = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            rb.gravityScale = 4;
            canJump = false;
        }
    }

    void PhysicsCheck()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        if (isGround)
        {
            rb.gravityScale = 1;
            isJump = false;
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
    }
}
