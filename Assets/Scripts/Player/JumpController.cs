using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    [SerializeField] float jumpForce = 0f;
    [SerializeField] float doubleJumpForce = 0f;
    [SerializeField] float jumpTimeCounter = 0f;
    [SerializeField] float jumpTimeLimit = 0f;
    [SerializeField] float doubleJumpTimeLimit = 0f;
    [SerializeField] int jumpCount = 0;
    [SerializeField] int jumpLimit = 0;

    [Header("Recent Status")]
    [SerializeField] bool isGround = true;
    [SerializeField] bool canJump = false;
    [SerializeField] bool isJump = false;

    [Header("Ground Check")]
    [SerializeField] Transform groundCheck = null;
    [SerializeField] float checkRadius = 0f;
    [SerializeField] LayerMask groundLayer = 0;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        //JumpForce();
    }

    // Update in a certain interval
    private void FixedUpdate()
    {
        PhysicCheck();
        Jump();
    }

    // Check jump input
    void CheckInput()
    {
        // Begin to jump
        if (Input.GetButtonDown("Jump") && isGround)
        {
            jumpTimeCounter = jumpTimeLimit;
        }

        // Jump
        if (Input.GetButton("Jump") && jumpCount < 1)
        {
            if (jumpTimeCounter > 0)
            {
                canJump = true;
                jumpTimeCounter -= Time.deltaTime;
            }
        }

        // End jumping
        if (Input.GetButtonUp("Jump"))
        {
            jumpCount += 1;
        }

        // Begin to double Jump
        if (Input.GetButtonDown("Jump") && !isGround && jumpCount < jumpLimit)
        {
            jumpTimeCounter = doubleJumpTimeLimit;
        }

        // Double jump
        if (Input.GetButton("Jump") && jumpCount >= 1 && jumpCount < jumpLimit)
        {
            if (jumpTimeCounter > 0)
            {
                canJump = true;
                jumpTimeCounter -= Time.deltaTime;
            }
        }
    }

    // Control kid to jump
    void Jump()
    {
        if (canJump)
        {
            isJump = true;
            if (jumpCount >= 1)
            {
                rb.velocity = new Vector2(rb.velocity.x, doubleJumpForce);
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
            canJump = false;
        }
    }

    // Ground check
    void PhysicCheck()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
        if (isGround)
        {
            isJump = false;
            jumpCount = 0;
        }
    }

    // Draw a gizmos for ground check
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
    }

    public bool GetIsJump() => isJump;
    public bool GetIsGround() => isGround;
}
