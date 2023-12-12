using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed;

    public float jumpForce;

    private bool jumpPressed;

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
        Movement();
        Jump();
    }

    void CheckInput()
    {
        if(Input.GetButtonDown("Jump"))
        {
            jumpPressed = true;
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
        if(jumpPressed)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpPressed = false;
        }
    }
}
